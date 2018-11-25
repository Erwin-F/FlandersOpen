import React, { Component } from "react";
import { Switch, Route } from "react-router-dom";
import { DefaultLayout } from "./components/common/DefaultLayout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { AutoBindCounter } from "./components/AutoBindCounter";
import { NoNavigation } from "./components/common/NoNavigation";
import AppRoute from "./components/common/AppRoute";
import NavLayout from "./components/common/NavLayout";
import NoMenuLayout from "./components/common/NoMenuLayout";

export const routes = (
  <DefaultLayout>
    <Switch>
      <AppRoute exact path="/" layout={NavLayout} component={Home} />
      <AppRoute path="/counter"  layout={NavLayout} component={AutoBindCounter} />
      <AppRoute path="/fetchdata"  layout={NavLayout} component={FetchData} />
      <AppRoute path="/nonavigation"  layout={NoMenuLayout} component={NoNavigation} />
    </Switch>
  </DefaultLayout>
);
