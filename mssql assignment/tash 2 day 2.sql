--1.
SELECT * FROM customers ORDER BY first_name DESC;
--2.
SELECT first_name, last_name, city 
FROM customers 
ORDER BY city ASC, first_name ASC;
--3.
SELECT TOP 3 * 
FROM products 
ORDER BY list_price DESC;
--4.
SELECT * 
FROM products 
WHERE list_price > 300 AND model_year = 2018;
--5.
SELECT * 
FROM products 
WHERE list_price > 3000 OR model_year = 2018;
--6.
SELECT * 
FROM products 
WHERE list_price BETWEEN 1899 AND 1999.99;
--7.
SELECT * 
FROM products 
WHERE list_price IN (299.99, 466.99, 489.99);
--8.
SELECT * 
FROM customers 
WHERE LEFT(last_name, 1) BETWEEN 'A' AND 'C';
--9.
SELECT * 
FROM customers 
WHERE first_name NOT LIKE 'A%';
--10.
SELECT state, city, COUNT(*) AS customer_count
FROM customers 
GROUP BY state, city;
--11.
SELECT customer_id, YEAR(order_date) AS order_year, COUNT(*) AS total_orders
FROM orders 
GROUP BY customer_id, YEAR(order_date);
--12.
SELECT category_id, 
       MAX(list_price) AS max_price, 
       MIN(list_price) AS min_price
FROM products 
GROUP BY category_id
HAVING MAX(list_price) > 4000 OR MIN(list_price) < 500;


