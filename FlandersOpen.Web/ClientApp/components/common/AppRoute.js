import React from "react";
import { Route, Redirect } from "react-router-dom";

const AppRoute = ({ component: Component, layout: Layout, private: Private, ...rest }) => (
  <Route {...rest} render={props => (
    Private && !localStorage.getItem("user") 
    ? <Redirect to={{ pathname: '/login', state: { from: props.location } }} /> 
    : <Layout><Component {...props} /></Layout>)} 
  />
);

export default AppRoute;

/*
import React from 'react';
import { Route, Redirect } from 'react-router-dom';
 
export const PrivateRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={props => (
        localStorage.getItem('user')
            ? <Component {...props} />
            : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
    )} />
)



if private true
      if localstorage


      als private && localstorage => component
      als private && !localstorage => redirect
      als !private => component
*/ 