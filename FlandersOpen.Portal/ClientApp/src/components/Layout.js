import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { AppContext } from "../components/common/AppContext";

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
          <NavMenu />
          <AppContext.Consumer>
            {(context) => (context.fullWidth ? this.props.children : <Container>{this.props.children}</Container>)}
          </AppContext.Consumer>
      </div>
    );
  }
}
