import React, { Component } from "react";
import AppProvider from "./AppProvider";
import { AppContext } from "./AppContext";
import Loader from "./Loader";

export class DefaultLayout extends Component {
  render() {
    return (
      <AppProvider>
        <div className="container-fluid">
          <div className="row">
          <AppContext.Consumer>
              {(context) => (context.ajaxCounter <= 0 ?
              this.props.children : <Loader />
              )}
            </AppContext.Consumer>
          </div>
        </div>
      </AppProvider>
    );
  }
}