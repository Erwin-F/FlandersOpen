import React from "react";
import PropTypes from "prop-types";

const NoMenuLayout = (props) => (
    <React.Fragment>
        <div>
            {props.children}
        </div>
    </React.Fragment>
);

NoMenuLayout.propTypes = {
    children: PropTypes.object.isRequired
  };  

export default NoMenuLayout;
