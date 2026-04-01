--
-- PostgreSQL database dump
--

\restrict vDWpmhFtf8OwOxpSbAq7xE5qOK8pdLN7vDZndaehWcH6rENxZbw0oARSMmsbCs4

-- Dumped from database version 18.1
-- Dumped by pg_dump version 18.1

-- Started on 2026-03-30 10:46:57

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
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
-- TOC entry 219 (class 1259 OID 16524)
-- Name: dailyplans; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dailyplans (
    plan_id integer NOT NULL,
    user_id integer,
    plan_date date NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.dailyplans OWNER TO postgres;

--
-- TOC entry 5100 (class 0 OID 0)
-- Dependencies: 219
-- Name: TABLE dailyplans; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.dailyplans IS 'Stores daily study plans generated for users';


--
-- TOC entry 220 (class 1259 OID 16530)
-- Name: dailyplans_plan_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.dailyplans_plan_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.dailyplans_plan_id_seq OWNER TO postgres;

--
-- TOC entry 5101 (class 0 OID 0)
-- Dependencies: 220
-- Name: dailyplans_plan_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.dailyplans_plan_id_seq OWNED BY public.dailyplans.plan_id;


--
-- TOC entry 221 (class 1259 OID 16531)
-- Name: dailyplantasks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.dailyplantasks (
    plan_task_id integer NOT NULL,
    plan_id integer,
    task_id integer,
    task_order integer
);


ALTER TABLE public.dailyplantasks OWNER TO postgres;

--
-- TOC entry 5102 (class 0 OID 0)
-- Dependencies: 221
-- Name: TABLE dailyplantasks; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.dailyplantasks IS 'Links tasks to daily plans with ordering';


--
-- TOC entry 222 (class 1259 OID 16535)
-- Name: dailyplantasks_plan_task_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.dailyplantasks_plan_task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.dailyplantasks_plan_task_id_seq OWNER TO postgres;

--
-- TOC entry 5103 (class 0 OID 0)
-- Dependencies: 222
-- Name: dailyplantasks_plan_task_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.dailyplantasks_plan_task_id_seq OWNED BY public.dailyplantasks.plan_task_id;


--
-- TOC entry 223 (class 1259 OID 16536)
-- Name: subjects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subjects (
    subject_id integer NOT NULL,
    user_id integer,
    subject_name character varying(100) NOT NULL
);


ALTER TABLE public.subjects OWNER TO postgres;

--
-- TOC entry 5104 (class 0 OID 0)
-- Dependencies: 223
-- Name: TABLE subjects; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.subjects IS 'Stores subjects created by users';


--
-- TOC entry 224 (class 1259 OID 16541)
-- Name: subjects_subject_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subjects_subject_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.subjects_subject_id_seq OWNER TO postgres;

--
-- TOC entry 5105 (class 0 OID 0)
-- Dependencies: 224
-- Name: subjects_subject_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subjects_subject_id_seq OWNED BY public.subjects.subject_id;


--
-- TOC entry 225 (class 1259 OID 16542)
-- Name: tasks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tasks (
    task_id integer NOT NULL,
    subject_id integer,
    description text,
    estimated_min integer DEFAULT 30,
    priority integer DEFAULT 1,
    due_date date,
    completed boolean DEFAULT false,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    completed_at timestamp without time zone,
    actual_minutes integer,
    user_id integer
);


ALTER TABLE public.tasks OWNER TO postgres;

--
-- TOC entry 5106 (class 0 OID 0)
-- Dependencies: 225
-- Name: TABLE tasks; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.tasks IS 'Stores tasks associated with subjects';


--
-- TOC entry 226 (class 1259 OID 16552)
-- Name: tasks_task_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tasks_task_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tasks_task_id_seq OWNER TO postgres;

--
-- TOC entry 5107 (class 0 OID 0)
-- Dependencies: 226
-- Name: tasks_task_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tasks_task_id_seq OWNED BY public.tasks.task_id;


--
-- TOC entry 227 (class 1259 OID 16553)
-- Name: userpasswords; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.userpasswords (
    password_id integer NOT NULL,
    user_id integer,
    hashed_password character varying(255) NOT NULL,
    salt character varying(50) NOT NULL
);


ALTER TABLE public.userpasswords OWNER TO postgres;

--
-- TOC entry 5108 (class 0 OID 0)
-- Dependencies: 227
-- Name: TABLE userpasswords; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.userpasswords IS 'Stores hashed passwords with salt';


--
-- TOC entry 228 (class 1259 OID 16559)
-- Name: userpasswords_password_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.userpasswords_password_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.userpasswords_password_id_seq OWNER TO postgres;

--
-- TOC entry 5109 (class 0 OID 0)
-- Dependencies: 228
-- Name: userpasswords_password_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.userpasswords_password_id_seq OWNED BY public.userpasswords.password_id;


--
-- TOC entry 229 (class 1259 OID 16560)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    user_id integer NOT NULL,
    username character varying(50) NOT NULL,
    user_email character varying(100) NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    last_login timestamp without time zone
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 5110 (class 0 OID 0)
-- Dependencies: 229
-- Name: TABLE users; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.users IS 'Stores user account information';


--
-- TOC entry 230 (class 1259 OID 16567)
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_user_id_seq OWNER TO postgres;

--
-- TOC entry 5111 (class 0 OID 0)
-- Dependencies: 230
-- Name: users_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;


--
-- TOC entry 231 (class 1259 OID 16568)
-- Name: usersettings; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.usersettings (
    user_id integer NOT NULL,
    max_daily_tasks integer DEFAULT 5,
    enable_notifcations boolean DEFAULT true,
    region character varying(10) DEFAULT 'en'::character varying,
    max_holiday_daily_tasks integer
);


ALTER TABLE public.usersettings OWNER TO postgres;

--
-- TOC entry 5112 (class 0 OID 0)
-- Dependencies: 231
-- Name: TABLE usersettings; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.usersettings IS 'Stores user preferences and settings';


--
-- TOC entry 4885 (class 2604 OID 16575)
-- Name: dailyplans plan_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplans ALTER COLUMN plan_id SET DEFAULT nextval('public.dailyplans_plan_id_seq'::regclass);


--
-- TOC entry 4887 (class 2604 OID 16576)
-- Name: dailyplantasks plan_task_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplantasks ALTER COLUMN plan_task_id SET DEFAULT nextval('public.dailyplantasks_plan_task_id_seq'::regclass);


--
-- TOC entry 4888 (class 2604 OID 16577)
-- Name: subjects subject_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subjects ALTER COLUMN subject_id SET DEFAULT nextval('public.subjects_subject_id_seq'::regclass);


--
-- TOC entry 4889 (class 2604 OID 16578)
-- Name: tasks task_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tasks ALTER COLUMN task_id SET DEFAULT nextval('public.tasks_task_id_seq'::regclass);


--
-- TOC entry 4894 (class 2604 OID 16579)
-- Name: userpasswords password_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userpasswords ALTER COLUMN password_id SET DEFAULT nextval('public.userpasswords_password_id_seq'::regclass);


--
-- TOC entry 4895 (class 2604 OID 16580)
-- Name: users user_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);


--
-- TOC entry 5082 (class 0 OID 16524)
-- Dependencies: 219
-- Data for Name: dailyplans; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.dailyplans (plan_id, user_id, plan_date, created_at) FROM stdin;
1	1	2026-03-25	2026-03-25 13:01:34.557547
2	1	2026-03-26	2026-03-26 11:03:03.211941
6	1	2026-03-29	2026-03-29 17:59:02.527854
\.


--
-- TOC entry 5084 (class 0 OID 16531)
-- Dependencies: 221
-- Data for Name: dailyplantasks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.dailyplantasks (plan_task_id, plan_id, task_id, task_order) FROM stdin;
1	1	11	1
2	1	9	2
9	2	11	1
10	2	9	2
17	6	11	1
18	6	9	2
\.


--
-- TOC entry 5086 (class 0 OID 16536)
-- Dependencies: 223
-- Data for Name: subjects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.subjects (subject_id, user_id, subject_name) FROM stdin;
1	2	asdf
3	2	a
4	2	asdf
24	1	asdf
27	1	Qwer
\.


--
-- TOC entry 5088 (class 0 OID 16542)
-- Dependencies: 225
-- Data for Name: tasks; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tasks (task_id, subject_id, description, estimated_min, priority, due_date, completed, created_at, completed_at, actual_minutes, user_id) FROM stdin;
9	24	asdf	0	1	2026-02-20	f	2026-02-20 12:07:10.448698	\N	\N	1
10	24	asdfasdfas	2	2	2026-02-24	f	2026-02-24 07:09:02.184675	\N	\N	1
11	24	finish task	1	1	2026-02-28	t	2026-02-27 14:22:10.480754	2026-03-29 17:12:30.894209	\N	1
\.


--
-- TOC entry 5090 (class 0 OID 16553)
-- Dependencies: 227
-- Data for Name: userpasswords; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.userpasswords (password_id, user_id, hashed_password, salt) FROM stdin;
1	1	mCfS2Yin/BtbXsGCOOIhOYt0xSVrGW4au7nZjyWgz3g=	0wnxK8nD!OzvUkTX
2	2	Pb3EbPGva7UOEXQWJwOkIe7nVHRC+tH/xQFeGdk6z0Y=	YMNJWs3bEoRdOuTn
3	3	ZYnXgDQr8RsyaCHl8VWdx2kB5/It7fGAhPDXz88EnSM=	WWv3mE7HkgTDgODz
\.


--
-- TOC entry 5092 (class 0 OID 16560)
-- Dependencies: 229
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (user_id, username, user_email, created_at, last_login) FROM stdin;
1	Username	Email@gmail.com	2026-02-08 15:50:52.190306	-infinity
2	Username2	Email2@gmail.com	2026-02-08 15:51:34.556003	-infinity
3	Testing	asdf@gamil.com	2026-02-26 11:41:51.304713	-infinity
\.


--
-- TOC entry 5094 (class 0 OID 16568)
-- Dependencies: 231
-- Data for Name: usersettings; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.usersettings (user_id, max_daily_tasks, enable_notifcations, region, max_holiday_daily_tasks) FROM stdin;
\.


--
-- TOC entry 5113 (class 0 OID 0)
-- Dependencies: 220
-- Name: dailyplans_plan_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.dailyplans_plan_id_seq', 9, true);


--
-- TOC entry 5114 (class 0 OID 0)
-- Dependencies: 222
-- Name: dailyplantasks_plan_task_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.dailyplantasks_plan_task_id_seq', 18, true);


--
-- TOC entry 5115 (class 0 OID 0)
-- Dependencies: 224
-- Name: subjects_subject_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subjects_subject_id_seq', 27, true);


--
-- TOC entry 5116 (class 0 OID 0)
-- Dependencies: 226
-- Name: tasks_task_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tasks_task_id_seq', 11, true);


--
-- TOC entry 5117 (class 0 OID 0)
-- Dependencies: 228
-- Name: userpasswords_password_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.userpasswords_password_id_seq', 3, true);


--
-- TOC entry 5118 (class 0 OID 0)
-- Dependencies: 230
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_user_id_seq', 3, true);


--
-- TOC entry 4901 (class 2606 OID 16582)
-- Name: dailyplans dailyplans_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplans
    ADD CONSTRAINT dailyplans_pkey PRIMARY KEY (plan_id);


--
-- TOC entry 4903 (class 2606 OID 16584)
-- Name: dailyplans dailyplans_user_id_plan_date_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplans
    ADD CONSTRAINT dailyplans_user_id_plan_date_key UNIQUE (user_id, plan_date);


--
-- TOC entry 4907 (class 2606 OID 16586)
-- Name: dailyplantasks dailyplantasks_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplantasks
    ADD CONSTRAINT dailyplantasks_pkey PRIMARY KEY (plan_task_id);


--
-- TOC entry 4909 (class 2606 OID 16588)
-- Name: dailyplantasks dailyplantasks_plan_id_task_id_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplantasks
    ADD CONSTRAINT dailyplantasks_plan_id_task_id_key UNIQUE (plan_id, task_id);


--
-- TOC entry 4912 (class 2606 OID 16590)
-- Name: subjects subjects_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subjects
    ADD CONSTRAINT subjects_pkey PRIMARY KEY (subject_id);


--
-- TOC entry 4917 (class 2606 OID 16592)
-- Name: tasks tasks_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tasks
    ADD CONSTRAINT tasks_pkey PRIMARY KEY (task_id);


--
-- TOC entry 4919 (class 2606 OID 16594)
-- Name: userpasswords userpasswords_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userpasswords
    ADD CONSTRAINT userpasswords_pkey PRIMARY KEY (password_id);


--
-- TOC entry 4921 (class 2606 OID 16596)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);


--
-- TOC entry 4923 (class 2606 OID 16598)
-- Name: users users_user_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_user_email_key UNIQUE (user_email);


--
-- TOC entry 4925 (class 2606 OID 16600)
-- Name: users users_username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_username_key UNIQUE (username);


--
-- TOC entry 4927 (class 2606 OID 16602)
-- Name: usersettings usersettings_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usersettings
    ADD CONSTRAINT usersettings_pkey PRIMARY KEY (user_id);


--
-- TOC entry 4904 (class 1259 OID 16603)
-- Name: idx_daily_plans_date; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_daily_plans_date ON public.dailyplans USING btree (plan_date);


--
-- TOC entry 4905 (class 1259 OID 16604)
-- Name: idx_daily_plans_user; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_daily_plans_user ON public.dailyplans USING btree (user_id);


--
-- TOC entry 4910 (class 1259 OID 16605)
-- Name: idx_subjects_user; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_subjects_user ON public.subjects USING btree (user_id);


--
-- TOC entry 4913 (class 1259 OID 16606)
-- Name: idx_tasks_completed; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_tasks_completed ON public.tasks USING btree (completed);


--
-- TOC entry 4914 (class 1259 OID 16607)
-- Name: idx_tasks_due_date; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_tasks_due_date ON public.tasks USING btree (due_date);


--
-- TOC entry 4915 (class 1259 OID 16608)
-- Name: idx_tasks_user; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX idx_tasks_user ON public.tasks USING btree (subject_id);


--
-- TOC entry 4928 (class 2606 OID 16609)
-- Name: dailyplans dailyplans_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplans
    ADD CONSTRAINT dailyplans_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- TOC entry 4929 (class 2606 OID 16614)
-- Name: dailyplantasks dailyplantasks_plan_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplantasks
    ADD CONSTRAINT dailyplantasks_plan_id_fkey FOREIGN KEY (plan_id) REFERENCES public.dailyplans(plan_id) ON DELETE CASCADE;


--
-- TOC entry 4930 (class 2606 OID 16619)
-- Name: dailyplantasks dailyplantasks_task_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.dailyplantasks
    ADD CONSTRAINT dailyplantasks_task_id_fkey FOREIGN KEY (task_id) REFERENCES public.tasks(task_id) ON DELETE CASCADE;


--
-- TOC entry 4931 (class 2606 OID 16624)
-- Name: subjects subjects_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subjects
    ADD CONSTRAINT subjects_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- TOC entry 4932 (class 2606 OID 16629)
-- Name: tasks tasks_subject_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tasks
    ADD CONSTRAINT tasks_subject_id_fkey FOREIGN KEY (subject_id) REFERENCES public.subjects(subject_id) ON DELETE CASCADE;


--
-- TOC entry 4933 (class 2606 OID 16634)
-- Name: userpasswords userpasswords_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.userpasswords
    ADD CONSTRAINT userpasswords_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- TOC entry 4934 (class 2606 OID 16639)
-- Name: usersettings usersettings_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usersettings
    ADD CONSTRAINT usersettings_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


-- Completed on 2026-03-30 10:46:57

--
-- PostgreSQL database dump complete
--

\unrestrict vDWpmhFtf8OwOxpSbAq7xE5qOK8pdLN7vDZndaehWcH6rENxZbw0oARSMmsbCs4

