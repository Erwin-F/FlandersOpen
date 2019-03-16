import React from "react";
import { PublicMenu } from "./PublicMenu";
import { PrivateMenu } from "./PrivateMenu";
import PropTypes from "prop-types";

import { Sidebar, Menu, Segment } from "semantic-ui-react";

const MenuLayout = (props) => (
  <React.Fragment>
    {localStorage.getItem("user") ? <PrivateMenu /> : <PublicMenu />}
    <Segment basic style={{ marginLeft: "7em" }}>
        {props.children}
    </Segment>
  </React.Fragment>
);

MenuLayout.propTypes = {
  children: PropTypes.object.isRequired
};

export default MenuLayout;
