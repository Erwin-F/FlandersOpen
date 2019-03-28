import React, { Component } from "react";
import { Switch, Route } from "react-router-dom";

import DefaultLayout from "./components/layout/DefaultLayout";
import AppRoute from "./components/common/AppRoute";
import MenuLayout from "./components/layout/MenuLayout";
import NoMenuLayout from "./components/layout/NoMenuLayout";

import UsersPage from "./components/Users/UsersPage";
import LoginPage from "./components/Login/LoginPage";
import CompetitionsPage from "./components/Competitions/CompetitionsPage";
import TeamsPage from "./components/Teams/TeamsPage";
import RegisterPage from "./components/RegisterPage/RegisterPage";

//TODO To remove
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { AutoBindCounter } from "./components/AutoBindCounter";
import { NoNavigation } from "./components/common/NoNavigation";


export const routes = (
  <DefaultLayout>
    <Switch>
      <AppRoute exact path="/" layout={MenuLayout} component={Home} />
      <AppRoute path="/counter"  layout={MenuLayout} component={AutoBindCounter} />
      <AppRoute path="/fetchdata"  layout={MenuLayout} component={FetchData} />
      <AppRoute path="/nonavigation"  layout={NoMenuLayout} component={NoNavigation} />
      <AppRoute path="/counterprivate"  layout={MenuLayout} private component={AutoBindCounter} />

      <AppRoute path="/users" layout={MenuLayout} private component={UsersPage} />
      <AppRoute path="/register" layout={MenuLayout} private component={RegisterPage} />

      <AppRoute path="/login" layout={MenuLayout} component={LoginPage} />      
      <AppRoute path="/competitions" layout={MenuLayout} private component={CompetitionsPage} />
      <AppRoute path="/teams" layout={MenuLayout} private component={TeamsPage} />
    </Switch>
  </DefaultLayout>
);
