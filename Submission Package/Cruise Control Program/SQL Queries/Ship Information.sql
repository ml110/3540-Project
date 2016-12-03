SELECT S.ship_name AS VESSEL, S.ship_callsign AS CALLSIGN, S.ship_IMOnumber AS IMO, concat(P.port_name, ", ", Co.country_name) AS REGPORT, CONCAT(J.job_title, " ",ST.staff_firstname, " ", ST.staff_lastname) AS CAPTAIN FROM SHIP AS S
INNER JOIN STAFF AS ST ON S.ship_captain = ST.staff_id
INNER JOIN JOBS AS J ON ST.job_id = J.job_id
INNER JOIN PORTS AS P ON S.ship_portofreg = P.port_id
INNER JOIN CITY AS C ON P.city_id = C.city_id
INNER JOIN COUNTRY AS Co ON C.country_id = Co.country_id
WHERE S.ship_id = 1;