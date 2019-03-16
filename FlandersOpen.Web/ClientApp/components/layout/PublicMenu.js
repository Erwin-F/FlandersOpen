import React, { Component } from "react";
import { Link, NavLink } from "react-router-dom";
import { AppContext } from "../common/AppContext";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import { Menu, Icon } from "semantic-ui-react";



export class PublicMenu extends Component {  
  render() {    

    const items = [
      { as: NavLink, content: "Home", to: "/", icon:"football ball" },
      { as: NavLink, content: "Counter", to: "/counter", icon:"th list" }
    ];

/*
                    const history = this.context.props.history;
                    history.push("/");




          <NavLink to={"/"} exact activeClassName="active">
          <Icon name="football ball"/> Home
        </NavLink>
          <NavLink to={"/counter"} activeClassName="active">
          <Icon name="th list"/> Counter
        </NavLink>

          <Menu.Header>
            <AppContext.Consumer>
              {(context) => (<span style={{color: "white"}}>FOR 2019 - ajaxCounter: {context.ajaxCounter}</span>)}
            </AppContext.Consumer>
          </Menu.Header>
          <Menu.Item header as={NavLink} exact to="/" children="Diplomat" >
            <Icon name="football ball"/> Home            
          </Menu.Item>
          <Menu.Item header as={NavLink} exact to="/counter" children="Diplomat" >
            <Icon name="th list"/> Counter
          </Menu.Item>
          <Menu.Item as={NavLink} exact to="fetchdata">
            <Icon name="th list"/>
            Fetch data
          </Menu.Item>
          <Menu.Item as={NavLink} exact to="login">
            <Icon name="user"/>
            Login
          </Menu.Item>

*/

    return (
        <Menu fixed="left" vertical inverted icon="labeled" items={items} />
    );
  }
}

/*


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
*/