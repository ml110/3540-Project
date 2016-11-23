SELECT G.gift_name, G.gift_price, concat(GT.sale_date, " ", GT.sale_time) AS saleTime, concat(P.pass_firstname, " ", P.pass_lastname) AS custName, WA.area_name, concat(S.staff_firstname, " ", S.staff_lastname) AS staffName FROM GIFT_TRANSACTION AS GT
INNER JOIN GIFTS AS G ON GT.gift_id = G.gift_id
INNER JOIN ROOM_PASSENGER AS RP ON GT.roomPass_id = RP.roomPass_id
INNER JOIN ROOM AS R ON RP.room_id = R.room_id
INNER JOIN PASSENGER AS P ON RP.pass_id = P.pass_id
INNER JOIN STAFF AS S ON GT.staff_id = S.staff_id
INNER JOIN WORKAREAS AS WA ON GT.shop_id = WA.area_id
WHERE RP.trip_id = 1 AND R.room_number = 122