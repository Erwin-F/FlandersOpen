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
            {this.props.children}
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