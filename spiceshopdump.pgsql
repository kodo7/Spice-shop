--
-- PostgreSQL database dump
--

-- Dumped from database version 12.2
-- Dumped by pg_dump version 12.2

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: garsvielu_cena_lielaka_neka_x(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.garsvielu_cena_lielaka_neka_x(x integer) RETURNS character varying
    LANGUAGE sql
    AS $_$ select spices.name from spices where spices.price_per_gram_euro > $1 $_$;


ALTER FUNCTION public.garsvielu_cena_lielaka_neka_x(x integer) OWNER TO postgres;

--
-- Name: kur_strada(character varying, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kur_strada(x character varying, y character varying) RETURNS character varying
    LANGUAGE sql
    AS $_$ select shop.city from shop, employees where employees.id_shop = shop.id_shop and name = $1 and surname = $2 $_$;


ALTER FUNCTION public.kur_strada(x character varying, y character varying) OWNER TO postgres;

--
-- Name: update_cena(numeric, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.update_cena(cena numeric, nosaukums character varying) RETURNS void
    LANGUAGE sql
    AS $_$ update spices set price_per_gram_euro = $1 where name like $2 $_$;


ALTER FUNCTION public.update_cena(cena numeric, nosaukums character varying) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: customer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.customer (
    id_customer integer NOT NULL,
    email character varying(50),
    phone integer,
    name character varying(20),
    surname character varying(20)
);


ALTER TABLE public.customer OWNER TO postgres;

--
-- Name: customer_id_customer_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.customer_id_customer_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.customer_id_customer_seq OWNER TO postgres;

--
-- Name: customer_id_customer_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.customer_id_customer_seq OWNED BY public.customer.id_customer;


--
-- Name: employees; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employees (
    id_emp integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    hire_date date,
    salary_euro numeric(7,2),
    id_shop integer,
    phone integer,
    id_manager integer
);


ALTER TABLE public.employees OWNER TO postgres;

--
-- Name: shop; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.shop (
    id_shop integer NOT NULL,
    country character varying(20),
    city character varying(20),
    street character varying(40)
);


ALTER TABLE public.shop OWNER TO postgres;

--
-- Name: darba_vieta; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.darba_vieta AS
 SELECT employees.name,
    employees.surname,
    shop.country,
    shop.city,
    shop.street
   FROM public.employees,
    public.shop
  WHERE (shop.id_shop = employees.id_shop);


ALTER TABLE public.darba_vieta OWNER TO postgres;

--
-- Name: delivery_address; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.delivery_address (
    id_delivery_address integer NOT NULL,
    country character varying(20),
    city character varying(20),
    street character varying(20)
);


ALTER TABLE public.delivery_address OWNER TO postgres;

--
-- Name: delivery_address_id_delivery_address_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.delivery_address_id_delivery_address_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.delivery_address_id_delivery_address_seq OWNER TO postgres;

--
-- Name: delivery_address_id_delivery_address_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.delivery_address_id_delivery_address_seq OWNED BY public.delivery_address.id_delivery_address;


--
-- Name: employees_id_emp_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employees_id_emp_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.employees_id_emp_seq OWNER TO postgres;

--
-- Name: employees_id_emp_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employees_id_emp_seq OWNED BY public.employees.id_emp;


--
-- Name: spices; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.spices (
    id_spice integer NOT NULL,
    id_spice_categories integer,
    name character varying(50) NOT NULL,
    price_per_gram_euro numeric(10,2)
);


ALTER TABLE public.spices OWNER TO postgres;

--
-- Name: garsvielas_cena_lielaka_neka_avg; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.garsvielas_cena_lielaka_neka_avg AS
 SELECT spices.name,
    spices.price_per_gram_euro
   FROM public.spices
  WHERE (spices.price_per_gram_euro > ( SELECT avg(spices_1.price_per_gram_euro) AS avg
           FROM public.spices spices_1));


ALTER TABLE public.garsvielas_cena_lielaka_neka_avg OWNER TO postgres;

--
-- Name: spice_categories; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.spice_categories (
    id_spice_categories integer NOT NULL,
    category character varying(30) NOT NULL
);


ALTER TABLE public.spice_categories OWNER TO postgres;

--
-- Name: garsvielas_kategorija; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.garsvielas_kategorija AS
 SELECT spices.name,
    spice_categories.category
   FROM public.spices,
    public.spice_categories
  WHERE (spices.id_spice_categories = spice_categories.id_spice_categories);


ALTER TABLE public.garsvielas_kategorija OWNER TO postgres;

--
-- Name: supply; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.supply (
    id_supply integer NOT NULL,
    id_spice integer NOT NULL,
    ammount_kg numeric(10,3),
    id_shop integer NOT NULL
);


ALTER TABLE public.supply OWNER TO postgres;

--
-- Name: garsvielu_daudzums; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.garsvielu_daudzums AS
 SELECT shop.city,
    spices.name,
    supply.ammount_kg
   FROM public.supply,
    public.spices,
    public.shop
  WHERE ((supply.id_spice = spices.id_spice) AND (supply.id_shop = shop.id_shop));


ALTER TABLE public.garsvielu_daudzums OWNER TO postgres;

--
-- Name: lielaks_neka_videjais_daudzums; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.lielaks_neka_videjais_daudzums AS
 SELECT spices.name
   FROM public.spices,
    public.supply,
    public.shop
  WHERE ((spices.id_spice = supply.id_spice) AND (supply.ammount_kg > ( SELECT avg(supply_1.ammount_kg) AS avg
           FROM public.supply supply_1
          WHERE (shop.id_shop = 1))) AND (shop.id_shop = 1) AND (shop.id_shop = supply.id_shop));


ALTER TABLE public.lielaks_neka_videjais_daudzums OWNER TO postgres;

--
-- Name: manager; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.manager (
    manager_id integer NOT NULL,
    id_emp integer NOT NULL
);


ALTER TABLE public.manager OWNER TO postgres;

--
-- Name: manager_manager_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.manager_manager_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.manager_manager_id_seq OWNER TO postgres;

--
-- Name: manager_manager_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.manager_manager_id_seq OWNED BY public.manager.manager_id;


--
-- Name: noliktava_procentuali; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.noliktava_procentuali AS
 SELECT spices.name,
    supply.ammount_kg,
    ((( SELECT supply_1.ammount_kg
           FROM public.supply supply_1,
            public.spices spices_1
          WHERE (spices_1.id_spice = supply_1.id_spice)) / sum(supply.ammount_kg)) * (100)::numeric) AS proc
   FROM public.spices,
    public.supply
  WHERE (spices.id_spice = supply.id_spice)
  GROUP BY spices.name, supply.ammount_kg;


ALTER TABLE public.noliktava_procentuali OWNER TO postgres;

--
-- Name: order_spices; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.order_spices (
    id_order_spices integer NOT NULL,
    id_spices integer,
    ammount_kg numeric(10,3),
    id_order integer
);


ALTER TABLE public.order_spices OWNER TO postgres;

--
-- Name: order_spices_id_order_spices_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.order_spices_id_order_spices_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.order_spices_id_order_spices_seq OWNER TO postgres;

--
-- Name: order_spices_id_order_spices_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.order_spices_id_order_spices_seq OWNED BY public.order_spices.id_order_spices;


--
-- Name: orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.orders (
    id_order integer NOT NULL,
    id_customer integer,
    order_date date,
    id_delivery_address integer
);


ALTER TABLE public.orders OWNER TO postgres;

--
-- Name: orders_id_order_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.orders_id_order_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.orders_id_order_seq OWNER TO postgres;

--
-- Name: orders_id_order_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.orders_id_order_seq OWNED BY public.orders.id_order;


--
-- Name: pasutijumi; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.pasutijumi AS
 SELECT customer.name,
    customer.surname,
    spices.name AS spice_name,
    order_spices.ammount_kg
   FROM public.customer,
    public.spices,
    public.orders,
    public.order_spices
  WHERE ((customer.id_customer = orders.id_customer) AND (orders.id_order = order_spices.id_order) AND (spices.id_spice = order_spices.id_spices));


ALTER TABLE public.pasutijumi OWNER TO postgres;

--
-- Name: shop_id_shop_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.shop_id_shop_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.shop_id_shop_seq OWNER TO postgres;

--
-- Name: shop_id_shop_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.shop_id_shop_seq OWNED BY public.shop.id_shop;


--
-- Name: spice_categories_id_spice_categories_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.spice_categories_id_spice_categories_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.spice_categories_id_spice_categories_seq OWNER TO postgres;

--
-- Name: spice_categories_id_spice_categories_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.spice_categories_id_spice_categories_seq OWNED BY public.spice_categories.id_spice_categories;


--
-- Name: spices_id_spice_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.spices_id_spice_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.spices_id_spice_seq OWNER TO postgres;

--
-- Name: spices_id_spice_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.spices_id_spice_seq OWNED BY public.spices.id_spice;


--
-- Name: supply_id_supply_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.supply_id_supply_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.supply_id_supply_seq OWNER TO postgres;

--
-- Name: supply_id_supply_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.supply_id_supply_seq OWNED BY public.supply.id_supply;


--
-- Name: veikala_menedzeris; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.veikala_menedzeris AS
 SELECT employees.name,
    employees.surname,
    shop.city
   FROM public.employees,
    public.shop,
    public.manager
  WHERE ((manager.id_emp = employees.id_emp) AND (employees.id_shop = shop.id_shop));


ALTER TABLE public.veikala_menedzeris OWNER TO postgres;

--
-- Name: customer id_customer; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customer ALTER COLUMN id_customer SET DEFAULT nextval('public.customer_id_customer_seq'::regclass);


--
-- Name: delivery_address id_delivery_address; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.delivery_address ALTER COLUMN id_delivery_address SET DEFAULT nextval('public.delivery_address_id_delivery_address_seq'::regclass);


--
-- Name: employees id_emp; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees ALTER COLUMN id_emp SET DEFAULT nextval('public.employees_id_emp_seq'::regclass);


--
-- Name: manager manager_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manager ALTER COLUMN manager_id SET DEFAULT nextval('public.manager_manager_id_seq'::regclass);


--
-- Name: order_spices id_order_spices; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_spices ALTER COLUMN id_order_spices SET DEFAULT nextval('public.order_spices_id_order_spices_seq'::regclass);


--
-- Name: orders id_order; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders ALTER COLUMN id_order SET DEFAULT nextval('public.orders_id_order_seq'::regclass);


--
-- Name: shop id_shop; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shop ALTER COLUMN id_shop SET DEFAULT nextval('public.shop_id_shop_seq'::regclass);


--
-- Name: spice_categories id_spice_categories; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spice_categories ALTER COLUMN id_spice_categories SET DEFAULT nextval('public.spice_categories_id_spice_categories_seq'::regclass);


--
-- Name: spices id_spice; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spices ALTER COLUMN id_spice SET DEFAULT nextval('public.spices_id_spice_seq'::regclass);


--
-- Name: supply id_supply; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supply ALTER COLUMN id_supply SET DEFAULT nextval('public.supply_id_supply_seq'::regclass);


--
-- Data for Name: customer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.customer (id_customer, email, phone, name, surname) FROM stdin;
1	janis@gmail.com	21214	Janis	Berzins
2	arturs@gmail.com	56214	Arturs	Kalnins
3	kristaps@gmail.com	91246	Kristaps	Liepa
4	karlis@gmail.com	21312	Karlis	Liepa
55	test	4124	test	test
56	sda	2314	sad	sda
57	sdgsdg	21241	fafasdfas	sdgsdg
\.


--
-- Data for Name: delivery_address; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.delivery_address (id_delivery_address, country, city, street) FROM stdin;
1	Latvia	Riga	Upes 4
2	Latvia	Jelgava	Akmens 4
3	Latvia	Daugavpils	Ozola 2-32
43	Latvia	Talsi	fgdgdf
44	test	test	test
45	Latvia	Riga	aaaa
46	fasf	sfafs	fasfs
47	dfggdf	dfgg	dfgfgd
\.


--
-- Data for Name: employees; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.employees (id_emp, name, surname, hire_date, salary_euro, id_shop, phone, id_manager) FROM stdin;
2	Armands	Ozols	2016-09-23	1320.23	1	23161	3
4	Inese	Kalnina	2013-01-12	1402.31	2	66161	3
5	Lauris	Lidaka	2019-10-26	920.31	2	99261	3
6	Sandis	Upe	2016-10-26	1020.31	2	23261	5
7	Rihards	Abols	2018-10-26	1230.31	3	43261	5
3	Maris	Jansons	2017-01-12	3002.90	1	31246	0
\.


--
-- Data for Name: manager; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.manager (manager_id, id_emp) FROM stdin;
1	2
2	4
3	7
\.


--
-- Data for Name: order_spices; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.order_spices (id_order_spices, id_spices, ammount_kg, id_order) FROM stdin;
1	1	0.100	1
2	4	0.050	1
4	2	0.030	3
5	6	0.010	3
6	3	0.200	4
7	5	0.040	4
135	1	5.000	43
136	3	2.000	43
137	5	3.000	43
138	6	4.000	43
139	3	8.000	43
140	2	232.000	44
141	3	22.000	44
142	5	66.000	44
143	3	23.000	45
144	6	23.000	45
145	6	12.000	45
\.


--
-- Data for Name: orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.orders (id_order, id_customer, order_date, id_delivery_address) FROM stdin;
1	1	2020-05-05	1
3	2	2020-05-04	2
4	3	2020-05-03	3
43	55	2021-05-01	45
44	56	2021-10-01	46
45	57	2022-01-01	47
\.


--
-- Data for Name: shop; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.shop (id_shop, country, city, street) FROM stdin;
1	Latvia	Riga	Liela 23
2	Latvia	Jelgava	Darba 12
3	Latvia	Daugavpils	Ezera 32
\.


--
-- Data for Name: spice_categories; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.spice_categories (id_spice_categories, category) FROM stdin;
1	Baking
2	Salts
3	Extracts
\.


--
-- Data for Name: spices; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.spices (id_spice, id_spice_categories, name, price_per_gram_euro) FROM stdin;
1	1	Apple Pie Spice	2.00
2	1	Cinnamon	3.00
3	2	Celery Salt	1.23
4	2	Garlic Salt	2.43
5	3	Almond Extract	3.73
6	3	Rose Water	0.78
\.


--
-- Data for Name: supply; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.supply (id_supply, id_spice, ammount_kg, id_shop) FROM stdin;
1	1	10.000	1
2	2	15.000	2
3	2	15.000	1
4	3	5.000	1
5	4	5.000	1
6	5	2.000	1
7	6	6.100	1
8	1	12.000	2
9	3	1.000	2
10	4	2.000	2
11	5	6.000	2
12	6	4.000	2
13	1	2.000	3
14	2	3.000	3
15	3	3.000	3
16	4	15.000	3
17	5	2.000	3
18	6	8.000	3
\.


--
-- Name: customer_id_customer_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.customer_id_customer_seq', 57, true);


--
-- Name: delivery_address_id_delivery_address_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.delivery_address_id_delivery_address_seq', 47, true);


--
-- Name: employees_id_emp_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employees_id_emp_seq', 7, true);


--
-- Name: manager_manager_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.manager_manager_id_seq', 3, true);


--
-- Name: order_spices_id_order_spices_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.order_spices_id_order_spices_seq', 145, true);


--
-- Name: orders_id_order_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.orders_id_order_seq', 45, true);


--
-- Name: shop_id_shop_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.shop_id_shop_seq', 3, true);


--
-- Name: spice_categories_id_spice_categories_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.spice_categories_id_spice_categories_seq', 6, true);


--
-- Name: spices_id_spice_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.spices_id_spice_seq', 7, true);


--
-- Name: supply_id_supply_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.supply_id_supply_seq', 18, true);


--
-- Name: customer customer_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customer
    ADD CONSTRAINT customer_pkey PRIMARY KEY (id_customer);


--
-- Name: delivery_address delivery_address_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.delivery_address
    ADD CONSTRAINT delivery_address_pkey PRIMARY KEY (id_delivery_address);


--
-- Name: employees employees_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT employees_pkey PRIMARY KEY (id_emp);


--
-- Name: manager manager_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manager
    ADD CONSTRAINT manager_pkey PRIMARY KEY (manager_id);


--
-- Name: order_spices order_spices_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_spices
    ADD CONSTRAINT order_spices_pkey PRIMARY KEY (id_order_spices);


--
-- Name: orders orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (id_order);


--
-- Name: shop shop_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shop
    ADD CONSTRAINT shop_pkey PRIMARY KEY (id_shop);


--
-- Name: spice_categories spice_categories_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spice_categories
    ADD CONSTRAINT spice_categories_pkey PRIMARY KEY (id_spice_categories);


--
-- Name: spices spices_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spices
    ADD CONSTRAINT spices_pkey PRIMARY KEY (id_spice);


--
-- Name: supply supply_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supply
    ADD CONSTRAINT supply_pkey PRIMARY KEY (id_supply);


--
-- Name: employees emp_shop; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employees
    ADD CONSTRAINT emp_shop FOREIGN KEY (id_shop) REFERENCES public.shop(id_shop) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: order_spices order_spices_order; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_spices
    ADD CONSTRAINT order_spices_order FOREIGN KEY (id_order) REFERENCES public.orders(id_order) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: order_spices order_spices_spices; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.order_spices
    ADD CONSTRAINT order_spices_spices FOREIGN KEY (id_spices) REFERENCES public.spices(id_spice) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: orders orders_customer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_customer FOREIGN KEY (id_customer) REFERENCES public.customer(id_customer) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: orders orders_delivery_address; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_delivery_address FOREIGN KEY (id_customer) REFERENCES public.customer(id_customer) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: spices spices_spice_categories; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spices
    ADD CONSTRAINT spices_spice_categories FOREIGN KEY (id_spice_categories) REFERENCES public.spice_categories(id_spice_categories) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: supply supply_shop; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supply
    ADD CONSTRAINT supply_shop FOREIGN KEY (id_shop) REFERENCES public.shop(id_shop) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: supply supply_spices; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.supply
    ADD CONSTRAINT supply_spices FOREIGN KEY (id_spice) REFERENCES public.spices(id_spice) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

