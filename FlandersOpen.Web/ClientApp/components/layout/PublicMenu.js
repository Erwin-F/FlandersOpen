import React, { Fragment } from "react";
import { AppContext } from "../common/AppContext";

import { Menu, MenuItem, Icon, Container } from "semantic-ui-react";
import AutoBindComponent from "../common/AutobindComponent";
import menuHelper from "./menuHelper";

export class PublicMenu extends AutoBindComponent {
    constructor(props, context){
    super(props, context);

    this.state = { activeItem: "" };
  }

  componentDidMount(){
    this.pageHelper = new menuHelper(this);
  }

  handleOnClick = (e, {name}) => this.pageHelper.onMenuClick(e, name);

  render() {
    const { activeItem } = this.state;

    return (
      <Menu fixed="top" inverted>
        <Container>
          <MenuItem name="home" active={activeItem === "home"} onClick={this.handleOnClick}>
              <AppContext.Consumer>
                {(context) => (
                  <Fragment>
                    <Icon name="football ball"/><span style={{color: "white"}}>FOR 2019 - ajaxCounter: {context.ajaxCounter}</span>
                  </Fragment>
                )}
              </AppContext.Consumer>
          </MenuItem>
          <MenuItem name="login" active={activeItem === "login"} onClick={this.handleOnClick}/>
        </Container>
      </Menu>
        );
  }
}