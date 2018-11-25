import React from "react";
import { NavMenu } from "./NavMenu";

const NavLayout = (props) => (
    <React.Fragment>
    <div className="col-sm-3">
    <NavMenu />
  </div>
  <div className="col-sm-9">{props.children}</div></React.Fragment>
);

export default NavLayout;
