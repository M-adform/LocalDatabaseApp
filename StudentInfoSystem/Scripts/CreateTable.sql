CREATE TABLE students (
	student_id serial PRIMARY KEY,
	student_name VARCHAR ( 50 ) NOT NULL,
	department_id INT NOT NULL
);

CREATE INDEX idx_students 
ON students(student_id);

CREATE TABLE departments (
	department_id serial PRIMARY KEY,
	department_name VARCHAR ( 50 ) UNIQUE NOT NULL
);

CREATE INDEX idx_departments
ON departments(department_id);

CREATE TABLE lectures (
	lecture_id serial PRIMARY KEY,
	lecture_name VARCHAR ( 50 ) UNIQUE NOT NULL
);

CREATE INDEX idx_lectures 
ON lectures(lecture_id);

CREATE TABLE student_lecture(
student_lecture_id serial PRIMARY KEY,
student_id INT, 
lecture_id INT,
FOREIGN KEY (lecture_id) REFERENCES lectures(lecture_id),
FOREIGN KEY (student_id) REFERENCES students(student_id)
);

CREATE INDEX idx_student_lecture 
ON student_lecture(student_id);

CREATE TABLE department_lecture(
department_lecture_id serial PRIMARY KEY,
department_id INT, 
lecture_id INT,
FOREIGN KEY (lecture_id) REFERENCES lectures(lecture_id),
FOREIGN KEY (department_id) REFERENCES departments(department_id)
);

CREATE INDEX idx_department_lecture
ON department_lecture(department_id);

