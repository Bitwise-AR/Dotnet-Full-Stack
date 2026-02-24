CREATE TABLE StudentCourseRaw (
    StudentId INT,
    StudentName VARCHAR(50),
    CourseName VARCHAR(50),
    TrainerName VARCHAR(50),
    CourseFee INT,
    JoiningDate DATE,
    ExamMonth INT,
    ExamYear INT,
    Marks INT
);

INSERT INTO StudentCourseRaw VALUES
(101, 'Kumar', 'SQL', 'Ramesh', 15000, '2021-06-15', 3, 2024, 85),
(101, 'Kumar', 'SQL', 'Ramesh', 15000, '2021-06-15', 9, 2024, 78),
(102, 'Anita', 'Java', 'Suresh', 18000, '2022-01-10', 3, 2024, 62),
(103, 'Rahul', 'Python', 'Meena', 20000, '2020-08-05', 11, 2023, 35);

SELECT * FROM StudentCourseRaw;

CREATE TABLE Student (
    StudentId INT PRIMARY KEY,
    StudentName VARCHAR(50),
    JoiningDate DATE
);

INSERT INTO Student (StudentId, StudentName, JoiningDate)
SELECT DISTINCT 
    StudentId, 
    StudentName, 
    JoiningDate
FROM StudentCourseRaw;

CREATE TABLE Trainer (
    TrainerId INT PRIMARY KEY,
    TrainerName VARCHAR(50)
);

INSERT INTO Trainer (TrainerId, TrainerName)
SELECT
    ROW_NUMBER() OVER (ORDER BY TrainerName) AS TrainerId,
    TrainerName
FROM (
    SELECT DISTINCT TrainerName
    FROM StudentCourseRaw
) T;

CREATE TABLE Course (
    CourseId INT PRIMARY KEY,
    CourseName VARCHAR(50),
    CourseFee INT,
    TrainerId INT,
    FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId)
);

INSERT INTO Course (CourseId, CourseName, CourseFee, TrainerId)
SELECT
    ROW_NUMBER() OVER (ORDER BY r.CourseName) AS CourseId,
    r.CourseName,
    r.CourseFee,
    t.TrainerId
FROM (
    SELECT DISTINCT CourseName, CourseFee, TrainerName
    FROM StudentCourseRaw
) r
INNER JOIN Trainer t
    ON r.TrainerName = t.TrainerName;

CREATE TABLE Marks (
    MarkId INT PRIMARY KEY,
    StudentId INT,
    CourseId INT,
    ExamMonth INT,
    ExamYear INT,
    Marks INT,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

INSERT INTO Marks (MarkId, StudentId, CourseId, ExamMonth, ExamYear, Marks)
SELECT
    ROW_NUMBER() OVER (ORDER BY r.StudentId) AS MarkId,
    r.StudentId,
    c.CourseId,
    r.ExamMonth,
    r.ExamYear,
    r.Marks
FROM StudentCourseRaw r
INNER JOIN Course c
    ON r.CourseName = c.CourseName;


SELECT * FROM Student;
SELECT * FROM Trainer;
SELECT * FROM Course;
SELECT * FROM Marks;


-- Q2
ALTER TABLE Student
ADD RewardPoints INT DEFAULT 0;

-- Q3
ALTER TABLE Student
ADD CONSTRAINT CHK_Student_RewardPoints
CHECK (RewardPoints BETWEEN 0 AND 100);

-- Q4
SELECT
    s.StudentName,
    c.CourseName,
    t.TrainerName,
    m.ExamMonth,
    m.ExamYear,
    m.Marks
FROM Marks m
INNER JOIN Student s ON m.StudentId = s.StudentId
INNER JOIN Course c ON m.CourseId = c.CourseId
INNER JOIN Trainer t ON c.TrainerId = t.TrainerId;

-- Q5
SELECT
    s.StudentName,
    SUM(m.Marks) AS TotalMarks
FROM Marks m
INNER JOIN Student s ON m.StudentId = s.StudentId
WHERE m.ExamYear = YEAR(GETDATE())
GROUP BY s.StudentName;

-- Q6
SELECT
    s.StudentName,
    LEFT(s.StudentName, 3)
    + LEFT(c.CourseName, 2)
    + CAST(s.StudentId AS VARCHAR(10)) AS LoginID
FROM Student s
INNER JOIN Marks m ON s.StudentId = m.StudentId
INNER JOIN Course c ON m.CourseId = c.CourseId;

-- Q7
SELECT
    s.StudentName,
    SUM(m.Marks) AS TotalMarks
FROM Marks m
INNER JOIN Student s ON m.StudentId = s.StudentId
GROUP BY s.StudentName
HAVING SUM(m.Marks) >
(
    SELECT AVG(StudentTotal)
    FROM (
        SELECT SUM(Marks) AS StudentTotal
        FROM Marks
        GROUP BY StudentId
    ) A
);

-- Q8
SELECT
    s.StudentName,
    m.Marks,
    'HIGH' AS Category
FROM Marks m
INNER JOIN Student s ON m.StudentId = s.StudentId
WHERE m.Marks > 80

UNION

SELECT
    s.StudentName,
    m.Marks,
    'LOW' AS Category
FROM Marks m
INNER JOIN Student s ON m.StudentId = s.StudentId
WHERE m.Marks < 40;

-- Q9
CREATE TRIGGER TRG_UpdateRewardPoints
ON Marks
AFTER INSERT
AS
BEGIN
    UPDATE s
    SET RewardPoints =
        COALESCE(s.RewardPoints, 0) +
        CASE
            WHEN i.Marks >= 80 THEN 10
            WHEN i.Marks >= 60 THEN 5
            ELSE 2
        END
    FROM Student s
    INNER JOIN inserted i
        ON s.StudentId = i.StudentId;
END;

-- Q10
SELECT
    s.StudentName,
    s.JoiningDate,
    DATEDIFF(YEAR, s.JoiningDate, GETDATE()) AS YearsOfStudy,
    CASE
        WHEN DATEDIFF(YEAR, s.JoiningDate, GETDATE()) >= 3
        THEN 10000
        ELSE 0
    END AS ScholarshipAmount
FROM Student s;
