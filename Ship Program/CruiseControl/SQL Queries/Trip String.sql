SELECT T.departure_date AS DEPARTDATE, P.port_name AS DEPARTPORT, C.city_name AS DEPARTCITY, P2.port_name AS DESTPORT, C2.city_name AS DESTCITY  FROM TRIP AS T
INNER JOIN PORTS AS P ON T.departure_port = P.port_id
INNER JOIN CITY AS C ON P.city_id = C.city_id
INNER JOIN PORTS AS P2 ON T.destination_port = P2.port_id
INNER JOIN CITY AS C2 ON P2.city_id = C2.city_id
WHERE T.trip_id = 1;