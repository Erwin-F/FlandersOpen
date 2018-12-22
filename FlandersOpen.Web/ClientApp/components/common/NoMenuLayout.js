import React from "react";
import PropTypes from "prop-types";

const NoMenuLayout = (props) => (
    <React.Fragment>
        <div className="col-sm-12">
            {props.children}
        </div>
    </React.Fragment>
);

NoMenuLayout.propTypes = {
    children: PropTypes.object.isRequired
  };  

export default NoMenuLayout;
