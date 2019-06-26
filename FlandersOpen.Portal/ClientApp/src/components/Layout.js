import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import AppProvider from "../components/common/AppProvider";
import { AppContext } from "../components/common/AppContext";

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <AppProvider>
          <NavMenu />
          <AppContext>
            {(context) => (context.fullWidth ? this.props.children : <Container>{this.props.children}</Container>)}
          </AppContext>
        </AppProvider>
      </div>
    );
  }
}
