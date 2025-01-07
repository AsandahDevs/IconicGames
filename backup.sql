--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

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
-- Name: Game; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Game" (
    "Id" integer NOT NULL,
    "GameTitle" text NOT NULL,
    "ReleaseYear" text NOT NULL,
    "Developers" text[] NOT NULL,
    "Revenue" numeric,
    "PublisherId" integer NOT NULL
);


--
-- Name: Game_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Game" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Game_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: Publisher; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Publisher" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL
);


--
-- Name: Publisher_Id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

ALTER TABLE public."Publisher" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Publisher_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- Data for Name: Game; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."Game" ("Id", "GameTitle", "ReleaseYear", "Developers", "Revenue", "PublisherId") FROM stdin;
1	Grand Theft Auto 5	2013	{"Rockstar North"}	17587560.35	1
2	Grand Theft Auto San Andreas	2004	{"Rockstar North"}	16589560.126	1
3	Grand Theft Auto Vice City	2002	{"Rockstar North"}	109876.15	1
\.


--
-- Data for Name: Publisher; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."Publisher" ("Id", "Name") FROM stdin;
1	Rockstar Games
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20250105204124_Modify-Model-Property-Order	9.0.0
\.


--
-- Name: Game_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Game_Id_seq"', 3, true);


--
-- Name: Publisher_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public."Publisher_Id_seq"', 1, true);


--
-- Name: Game PK_Game; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "PK_Game" PRIMARY KEY ("Id");


--
-- Name: Publisher PK_Publisher; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Publisher"
    ADD CONSTRAINT "PK_Publisher" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_Game_PublisherId; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Game_PublisherId" ON public."Game" USING btree ("PublisherId");


--
-- Name: Game FK_Game_Publisher_PublisherId; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Game"
    ADD CONSTRAINT "FK_Game_Publisher_PublisherId" FOREIGN KEY ("PublisherId") REFERENCES public."Publisher"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

