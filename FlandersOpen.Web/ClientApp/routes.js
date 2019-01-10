import React, { Component } from "react";
import { Switch, Route } from "react-router-dom";

import DefaultLayout from "./components/common/DefaultLayout";
import AppRoute from "./components/common/AppRoute";
import MenuLayout from "./components/common/MenuLayout";
import NoMenuLayout from "./components/common/NoMenuLayout";

import UsersPage from "./components/Users/UsersPage";
import LoginPage from "./components/Login/LoginPage";
import RegisterPage from "./components/Register/RegisterPage";
import CompetitionsPage from "./components/Competitions/CompetitionsPage";

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

      <AppRoute path="/login" layout={MenuLayout} component={LoginPage} />
      <AppRoute path="/register" layout={MenuLayout} component={RegisterPage} />
      <AppRoute path="/users" layout={MenuLayout} private component={UsersPage} />
      <AppRoute path="/competitions" layout={MenuLayout} private component={CompetitionsPage} />
    </Switch>
  </DefaultLayout>
);
