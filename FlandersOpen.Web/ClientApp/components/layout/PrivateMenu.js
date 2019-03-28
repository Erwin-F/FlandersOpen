import React, { Fragment } from "react";

import { Menu, MenuItem, Icon, Container, Dropdown, DropdownMenu, DropdownItem } from "semantic-ui-react";
import AutoBindComponent from "../common/AutobindComponent";
import menuHelper from "./menuHelper";

export class PrivateMenu extends AutoBindComponent {
    constructor(props, context){
    super(props, context);

    this.state = { activeItem: "" };
  }

  componentDidMount(){
    this.pageHelper = new menuHelper(this);
  }

  handleOnClick = (e, {name}) => this.pageHelper.onMenuClick(e, name);
  handleOnDropdownClick = (e, {value}) => this.pageHelper.onDropdownClick(e, value);
  handleOnLogout = () => this.pageHelper.onLogout();

  render() {
    const { activeItem } = this.state;

    return (
      <Menu fixed="top" inverted>
        <Container>
          <MenuItem name="home" active={activeItem === "home"} onClick={this.handleOnClick}>
            <Fragment>
              <Icon name="football ball"/><span style={{color: "white"}}>FOR 2019</span>
            </Fragment>
          </MenuItem>
          <Dropdown item text="Configuration">
            <DropdownMenu>
              <DropdownItem onClick={this.handleOnDropdownClick} active={activeItem === "competitions"} value="competitions">Competitions</DropdownItem>
              <DropdownItem onClick={this.handleOnDropdownClick} active={activeItem === "teams"} value="teams">Teams</DropdownItem>
              <DropdownItem onClick={this.handleOnDropdownClick} active={activeItem === "users"} value="users">Users</DropdownItem>
            </DropdownMenu>
          </Dropdown>
          <MenuItem name="counter" active={activeItem === "counter"} onClick={this.handleOnClick}/>
          <MenuItem name="fetchdata" active={activeItem === "fetchdata"} onClick={this.handleOnClick}/>
          <MenuItem name="logout" active={activeItem === "logout"} onClick={this.handleOnLogout}/>
        </Container>
      </Menu>
    );
  }
}