import React from "react";
import { PublicMenu } from "./PublicMenu";
import { PrivateMenu } from "./PrivateMenu";

const MenuLayout = (props) => (
    <React.Fragment>
      <div className="col-sm-3">
        {localStorage.getItem("user") ? <PrivateMenu /> : <PublicMenu />}
      </div>
      <div className="col-sm-9">
        {props.children}
      </div>
    </React.Fragment>
);

export default MenuLayout;
