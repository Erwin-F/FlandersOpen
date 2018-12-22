import React, { Component } from "react";
import { Link, NavLink } from "react-router-dom";
import { AppContext } from "./AppContext";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import { userService } from "../services/userService";

export class PublicMenu extends Component {
  render() {
    return (
      <React.Fragment>
        <div className="main-nav">
          <div className="navbar navbar-inverse">
            <div className="navbar-header">
              <button
                type="button"
                className="navbar-toggle"
                data-toggle="collapse"
                data-target=".navbar-collapse"
              >
                <span className="sr-only">Toggle navigation</span>
                <span className="icon-bar" />
                <span className="icon-bar" />
                <span className="icon-bar" />
              </button>
              <Link className="navbar-brand" to={"/"}>
                FlandersOpen.Web - 
                <AppContext.Consumer>
                    {(context) => (
                      <span> ajaxCounter: {context.ajaxCounter}</span>
                    )}
                  </AppContext.Consumer>
              </Link>
            </div>
            <div className="clearfix" />
            <div className="navbar-collapse collapse">
              <ul className="nav navbar-nav">
                <li>
                  <NavLink to={"/"} exact activeClassName="active">
                    <FontAwesomeIcon icon="football-ball" /> Home
                  </NavLink>
                </li>
                <li>
                  <NavLink to={"/counter"} activeClassName="active">
                  <FontAwesomeIcon icon="th-list" /> Counter
                  </NavLink>
                </li>
                <li>
                  <NavLink to={"/fetchdata"} activeClassName="active">
                  <FontAwesomeIcon icon="th-list" /> Fetch data
                  </NavLink>
                </li>
                <li>
                  <Link to={"/login"}>
                    <FontAwesomeIcon icon="user" /> Login
                  </Link>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  }
}
