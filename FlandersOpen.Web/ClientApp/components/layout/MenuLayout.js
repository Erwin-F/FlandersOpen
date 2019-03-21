import React from "react";
import { PublicMenu } from "./PublicMenu";
import { PrivateMenu } from "./PrivateMenu";
import PropTypes from "prop-types";
import { AppContext } from "../common/AppContext";

import { Segment, Container } from "semantic-ui-react";

import {withRouter} from "react-router-dom";

const MenuLayout = (props) => (
  <React.Fragment>
    {localStorage.getItem("user") ? <PrivateMenu history={props.history} /> : <PublicMenu history={props.history} />}
    <AppContext.Consumer>
    {(context) => (
      <Segment basic style={{ marginTop: "3em" }} loading={context.ajaxCounter !== 0}>
      <Container>
        {props.children}
      </Container>
    </Segment>)}
    </AppContext.Consumer>
  </React.Fragment>
);

MenuLayout.propTypes = {
  children: PropTypes.object.isRequired,
  history: PropTypes.object
};

export default withRouter(MenuLayout);
