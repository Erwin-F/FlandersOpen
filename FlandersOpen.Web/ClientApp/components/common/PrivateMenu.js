import React, { Component } from "react";
import { Link, NavLink } from "react-router-dom";
import { AppContext } from "./AppContext";
import { userService } from "../services/userService";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class PrivateMenu extends Component {
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
                  <NavLink to={"/competitions"} activeClassName="active">
                  <FontAwesomeIcon icon="th-list" /> Competitions
                  </NavLink>
                </li>
                <li>
                  <NavLink to={"/users"} activeClassName="active">
                    <FontAwesomeIcon icon="users" /> Users
                  </NavLink>
                </li>
                <li>
                  <Link to={"/"} onClick={userService.logout}>
                    <FontAwesomeIcon icon="user-slash" /> Logout
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
