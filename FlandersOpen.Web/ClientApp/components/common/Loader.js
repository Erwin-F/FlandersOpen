import React from "react";
import PropTypes from "prop-types";
import Spinner from "react-spinkit";

const Loader = (props) => {
    const loaderStyle = {
        float: "none",
        margin: "auto",
        marginTop: "25%"
    };

    return (
        <div className="col-md-1" style={loaderStyle}>
            <Spinner name="chasing-dots" />
        </div>
    );
};

Loader.propTypes = {
};

export default Loader;