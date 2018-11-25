import React, { Component } from "react";
import AppProvider from "./AppProvider";

export class DefaultLayout extends Component {
  render() {
    return (
      <AppProvider>
        <div className="container-fluid">
          <div className="row">
            {this.props.children}
          </div>
        </div>
      </AppProvider>
    );
  }
}
