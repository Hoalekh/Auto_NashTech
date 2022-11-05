SELECT * from employees;

SELECT e.employee_id, e.last_name,e.department_id,
		d.department_id, department_name, e.manager_id
FROM employees e JOIN departments d
ON (e.department_id = d.department_id)
AND e.manager_id=149
SELECT * FROM departments
--cau 1
SELECT * FROM employees WHERE last_name = 'Zlotkey'
-- cau2
SELECT * FROM employees WHERE department_id =80 and last_name <> 'Zlotkey'

--cach2 cau2 
SELECT *
	FROM employees 
	WHERE department_id =
		(
			SELECT department_id 
			FROM employees 
			WHERE last_name = 'Zlotkey'
	)
	AND last_name != 'Zlotkey'

--cau3
SELECT * FROM employees WHERE department_id in 
(SELECT department_id FROM employees WHERE 
 last_name = 'Zlotkey') and last_name <> 'Zlotkey'

 SELECT * FROM employees e1 
 inner join employees e2 on e1.department_id = e2.department_id
 WHERE e2.last_name = 'Zlotkey' and e1.last_name <>'Zlotkey'
 --cau 4
 SELECT employee_id, last_name,salary  FROM employees WHERE salary >= (SELECT AVG(salary) from employees)
 ORDER BY salary ASC
 --cau5
 SELECT employee_id, last_name  FROM employees WHERE department_id in
 (SELECT department_id from employees WHERE last_name like '%u%')
 --BT them

 SELECT last_name,department_id, job_id FROM employees
  WHERE department_id in (SELECT department_id  FROM departments WHERE location_id = 1700)

 SELECT * FROM employees e1 
 inner join departments e2 on e1.department_id = e2.department_id
 WHERE e2.location_id= 1700 

 SELECT last_name, e1.department_id FROM employees e1 
 inner join departments e2 on e1.department_id = e2.department_id
 inner join locations l on e2.location_id = l.location_id
 Where l.city='Seattle'

 SELECT employee_id , e1.department_id FROM employees e1 
 left join departments d on  e1.department_id =d.department_id;

SELECT * from employees e
Join departments d on e.department_id =d.department_id Where department_name = 'Finance'
union all
 SELECT * FROM employees e1 
 inner join departments e2 on e1.department_id = e2.department_id
 WHERE e2.location_id= 1700 
 --cau 6
 SELECT last_name, salary FROM employees  
Where last_name = 'King'
--cau7
SELECT e.employee_id, e.last_name, e.salary FROM employees e JOIN departments d
ON e.department_id = d.department_id
WHERE e.department_id IN (SELECT department_id
			FROM employees 
			WHERE last_name like '%u%')
AND salary > (SELECT AVG(salary)FROM employees);
 --cau8
 SELECT ROUND(MAX(salary),0) "Maximum",
ROUND(MIN(salary),0) "Minimum",
ROUND(SUM(salary),0) "Sum",
ROUND(AVG(salary),0) "Average"
FROM employees;

--cau 9
SELECT last_name 'Name',
LEN(last_name) 'Length'
FROM employees
 Where last_name like 'J%' OR last_name like 'M%'OR last_name like 'A%'
 ORDER by last_name;
 -- cau 10
 SELECT employee_id, last_name, salary, salary+(salary*15.5/100) "New Salary"
from employees;
--cau 11
SELECT last_name,department_id
FROM employees
UNION 
SELECT department_name, department_id
FROM departments


--cau12
--cach1
SELECT e.employee_id, e.last_name, e.hire_date
	FROM employees e, 
		(
			SELECT DISTINCT e1.employee_id, e2.employee_id 'manager_id', e2.hire_date
			FROM employees e1 LEFT JOIN employees e2 ON e1.manager_id = e2.employee_id
			WHERE e1.manager_id IS NOT NULL
		) m
	WHERE e.employee_id = m.employee_id AND DATEDIFF(day, e.hire_date, GETDATE()) < DATEDIFF(day, m.hire_date, GETDATE())
	UNION 
	SELECT employee_id, e.last_name, e.hire_date
	FROM employees e 
		LEFT JOIN departments d ON e.department_id = d.department_id
		LEFT JOIN locations l ON d.location_id = l.location_id 
	WHERE l.city = 'Toronto'
--cach 2
Select e1.employee_id,e1.last_name, e1.hire_date
From employees e1
         Inner join employees manager on manager.employee_id = e1.manager_id
Where e1.hire_date > manager.hire_date
Union
Select e2.employee_id, e2.last_name, e2.hire_date
From employees e2
         Inner join departments d on e2.department_id = d.department_id
         Inner join locations l on d.location_id = l.location_id
Where city = 'Toronto';
