import React, { Component } from "react";
import AppProvider from "../common/AppProvider";
import PropTypes from "prop-types";

class DefaultLayout extends Component {
  render() {
    return (
      <AppProvider>
            {this.props.children}
      </AppProvider>
    );
  }
}

DefaultLayout.propTypes = {
  children: PropTypes.object.isRequired
};

export default DefaultLayout;