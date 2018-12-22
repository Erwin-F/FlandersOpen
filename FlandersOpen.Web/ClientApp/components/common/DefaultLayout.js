import React, { Component } from "react";
import AppProvider from "./AppProvider";
import { AppContext } from "./AppContext";
import Loader from "./Loader";
import PropTypes from "prop-types";

class DefaultLayout extends Component {
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

DefaultLayout.propTypes = {
  children: PropTypes.object.isRequired
};

export default DefaultLayout;