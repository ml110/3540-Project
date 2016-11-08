SELECT SS.shift_date AS SHIFTDATE, concat(SH.shift_start, " - " , SH.shift_end) AS SHIFT, concat(ST.staff_lastname, ", ", ST.staff_firstname) AS STAFF, J.job_title, WA.area_name, D.dept_name FROM STAFF_SHIFT AS SS
INNER JOIN SHIFT AS SH ON SS.shift_id = SH.shift_id
INNER JOIN STAFF AS ST ON SS.staff_id = ST.staff_id
INNER JOIN JOBS AS J ON ST.job_id = J.job_id
INNER JOIN DEPARTMENT AS D ON J.dept_id = D.dept_id
INNER JOIN WORKAREAS AS WA ON SH.area_id = WA.area_id
WHERE SH.trip_id = 1 AND SS.shift_date = "2016-10-30"
ORDER BY SS.shift_date, SH.shift_start