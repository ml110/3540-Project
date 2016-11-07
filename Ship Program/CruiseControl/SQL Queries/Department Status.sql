SELECT D.dept_name AS DEPARTMENT, count(S.staff_id) AS NUMSTAFF FROM STAFF AS S 
INNER JOIN JOBS AS J ON S.job_id = J.job_id
INNER JOIN DEPARTMENT AS D ON J.dept_id = D.dept_id
WHERE S.ship_id = 1
GROUP BY D.dept_id