--
-- PostgreSQL database dump
--

-- Dumped from database version 15.3
-- Dumped by pg_dump version 15.3

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: equipments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.equipments (
    id integer NOT NULL,
    name text NOT NULL,
    manufacturerid integer
);


ALTER TABLE public.equipments OWNER TO postgres;

--
-- Name: equipments_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.equipments_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.equipments_id_seq OWNER TO postgres;

--
-- Name: equipments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.equipments_id_seq OWNED BY public.equipments.id;


--
-- Name: manufacturers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.manufacturers (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.manufacturers OWNER TO postgres;

--
-- Name: manufacturers_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.manufacturers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.manufacturers_id_seq OWNER TO postgres;

--
-- Name: manufacturers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.manufacturers_id_seq OWNED BY public.manufacturers.id;


--
-- Name: posts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.posts (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.posts OWNER TO postgres;

--
-- Name: posts_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.posts_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.posts_id_seq OWNER TO postgres;

--
-- Name: posts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.posts_id_seq OWNED BY public.posts.id;


--
-- Name: regions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.regions (
    code text NOT NULL,
    regiontypeid integer,
    name text NOT NULL
);


ALTER TABLE public.regions OWNER TO postgres;

--
-- Name: regiontypes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.regiontypes (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.regiontypes OWNER TO postgres;

--
-- Name: regiontypes_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.regiontypes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.regiontypes_id_seq OWNER TO postgres;

--
-- Name: regiontypes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.regiontypes_id_seq OWNED BY public.regiontypes.id;


--
-- Name: equipments id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.equipments ALTER COLUMN id SET DEFAULT nextval('public.equipments_id_seq'::regclass);


--
-- Name: manufacturers id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manufacturers ALTER COLUMN id SET DEFAULT nextval('public.manufacturers_id_seq'::regclass);


--
-- Name: posts id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts ALTER COLUMN id SET DEFAULT nextval('public.posts_id_seq'::regclass);


--
-- Name: regiontypes id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.regiontypes ALTER COLUMN id SET DEFAULT nextval('public.regiontypes_id_seq'::regclass);


--
-- Data for Name: equipments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.equipments (id, name, manufacturerid) FROM stdin;
1	Промышленный робот KUKA KR120 R3500	1
2	Промышленный Робот KUKA KR120 R3100-2	1
3	Автоматическая тележка AGV 7500 kg	1
4	Промышленный робот KUKA KR300LP 4ax V.cpl	1
5	Цепной конвейер для транспортировки досок	\N
6	Строгальный станок Powermat 700	2
7	Сканер Luxscan EasyScan	2
8	Оптимизирующая торцовочная пила OptiCut 260	2
9	Промышленный робот KUKA KR50 R2500	1
10	Ручная тележка	\N
11	Станок для обрезки углов	\N
12	Аппарат для нанесения клейма	\N
13	Автоматическая тележка AGV 1500 kg	1
14	Цепной 2-ручьевой транспортёр (1т)	\N
15	Линия расштабелирования	3
\.


--
-- Data for Name: manufacturers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.manufacturers (id, name) FROM stdin;
1	Kuka ROBOTICS
2	WEINIG Group
3	Megapak
\.


--
-- Data for Name: posts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.posts (id, name) FROM stdin;
1	Главный технолог
2	Старший специалист
3	Начальник смены
4	Менеджер по закупкам
5	Менеджер по продажам
6	Менеджер по персоналу
\.


--
-- Data for Name: regions; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.regions (code, regiontypeid, name) FROM stdin;
АИРП 01.00.000	1	Склад Пиломатериалов
АИРП 02.00.000	1	Штабелирование
АИРП 04.00.000	1	Сушка пиломатериалов
АИРП 06.00.000	1	Распиловочная линия
АИРП 10.00.000	1	Линия сборки поддонов (готовой продукции)
АИРП 14.00.000	1	Склад готовой продукции
АИРП 18.00.000	1	Склад Расходные материалы
\.


--
-- Data for Name: regiontypes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.regiontypes (id, name) FROM stdin;
1	Основной
2	Вспомогательный
\.


--
-- Name: equipments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.equipments_id_seq', 18, true);


--
-- Name: manufacturers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.manufacturers_id_seq', 5, true);


--
-- Name: posts_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.posts_id_seq', 7, true);


--
-- Name: regiontypes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.regiontypes_id_seq', 4, true);


--
-- Name: equipments equipments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.equipments
    ADD CONSTRAINT equipments_pkey PRIMARY KEY (id);


--
-- Name: manufacturers manufacturers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.manufacturers
    ADD CONSTRAINT manufacturers_pkey PRIMARY KEY (id);


--
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (id);


--
-- Name: regions regions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.regions
    ADD CONSTRAINT regions_pkey PRIMARY KEY (code);


--
-- Name: regiontypes regiontypes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.regiontypes
    ADD CONSTRAINT regiontypes_pkey PRIMARY KEY (id);


--
-- Name: equipments equipments_manufacturerid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.equipments
    ADD CONSTRAINT equipments_manufacturerid_fkey FOREIGN KEY (manufacturerid) REFERENCES public.manufacturers(id) ON DELETE SET NULL;


--
-- Name: regions regions_regiontypeid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.regions
    ADD CONSTRAINT regions_regiontypeid_fkey FOREIGN KEY (regiontypeid) REFERENCES public.regiontypes(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

