import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.toggleDropdown = this.toggleDropdown.bind(this);

    this.state = {
      navCollapsed: true,
      dropdownOpen: false
    };
  }

  toggleNavbar () {
    this.setState({
      navCollapsed: !this.state.navCollapsed
    });
  }

  toggleDropdown() {
    this.setState({
      dropdownOpen: !this.state.dropdownOpen
    });
  }

  render () {
    return (
      <header>
        <Navbar color="dark" dark expand="sm">
          <Container>
            <NavbarBrand tag={Link} to="/">FOR</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.navCollapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/counter">Counter</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-light" to="/fetch-data">Fetch data</NavLink>
                </NavItem>
                <Dropdown isOpen={this.state.dropdownOpen} toggle={this.toggleDropdown} nav>
                  <DropdownToggle nav caret className="text-light">
                    Configure
                  </DropdownToggle>
                  <DropdownMenu>
                    <DropdownItem>
                      <NavLink tag={Link} className="text-dark" to="/competitions">Competitions</NavLink>
                    </DropdownItem>
                    <DropdownItem>
                      <NavLink tag={Link} className="text-dark" to="/teams">Teams</NavLink>
                    </DropdownItem>
                    <DropdownItem divider />
                    <DropdownItem>
                      <NavLink tag={Link} className="text-dark" to="/tournament">Tournament</NavLink>
                    </DropdownItem>
                  </DropdownMenu>
                </Dropdown>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
