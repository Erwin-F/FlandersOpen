import React, { Component } from "react";
import { Switch, Route } from "react-router-dom";

import { DefaultLayout } from "./components/common/DefaultLayout";
import AppRoute from "./components/common/AppRoute";
import NavLayout from "./components/common/NavLayout";
import NoMenuLayout from "./components/common/NoMenuLayout";

import UsersPage from "./components/Users/UsersPage";
import LoginPage from "./components/Login/LoginPage";
import RegisterPage from "./components/Register/RegisterPage";

//TODO To remove
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { AutoBindCounter } from "./components/AutoBindCounter";
import { NoNavigation } from "./components/common/NoNavigation";


export const routes = (
  <DefaultLayout>
    <Switch>
      <AppRoute exact path="/" layout={NavLayout} component={Home} />
      <AppRoute path="/counter"  layout={NavLayout} component={AutoBindCounter} />      
      <AppRoute path="/fetchdata"  layout={NavLayout} component={FetchData} />
      <AppRoute path="/nonavigation"  layout={NoMenuLayout} component={NoNavigation} />
      <AppRoute path="/counterprivate"  layout={NavLayout} private component={AutoBindCounter} />

      <AppRoute path="/login" layout={NoMenuLayout} component={LoginPage} />
      <AppRoute path="/register" layout={NoMenuLayout} component={RegisterPage} />
      <AppRoute path="/users" layout={NavLayout} private component={UsersPage} />
    </Switch>
  </DefaultLayout>
);
