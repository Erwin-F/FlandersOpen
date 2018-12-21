import React from "react";

const NoMenuLayout = (props) => (
    <React.Fragment>
        <div className="col-sm-12">
            {props.children}
        </div>
    </React.Fragment>
);

export default NoMenuLayout;
