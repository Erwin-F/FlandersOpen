import React, { Component } from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent"
import UsersPageHelper from "./UsersPageHelper";

export class UsersPage extends AutoBindComponent {
    constructor(props, context) {
        super(props, context);

        this.state = { 
            users: [],
            user: null
        };

        this.pageHelper = new UsersPageHelper(this);
    }

    componentWillMount() {
        this.pageHelper.init();
    }

    render() {
        return (
            <div>
                Test
            </div>
        );
    }
}

export default React.forwardRef((props, ref) => (
    <AppContext.Consumer>
        {appContext => <UserPage {...props} appContext={appContext} ref={ref} />}
    </AppContext.Consumer>
));

/*
class Button extends React.Component {
  componentDidMount() {
    alert(this.props.theme);
  }

  render() {
    const { theme, children } = this.props;
    return (
      <button className={theme ? 'dark' : 'light'}>
        {children}
      </button>
    );
  }
}

export default React.forwardRef((props, ref) => (
  <ThemeContext.Consumer>
    {theme => <Button {...props} theme={theme} ref={ref} />}
  </ThemeContext.Consumer>
));
*/ 


/*
import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
 
import { userActions } from '../_actions';
 
class HomePage extends React.Component {
    componentDidMount() {
        this.props.dispatch(userActions.getAll());
    }
 
    handleDeleteUser(id) {
        return (e) => this.props.dispatch(userActions.delete(id));
    }
 
    render() {
        const { user, users } = this.props;
        return (
            <div className="col-md-6 col-md-offset-3">
                <h1>Hi {user.firstName}!</h1>
                <p>You're logged in with React and ASP.NET Core 2.0!!</p>
                <h3>All registered users:</h3>
                {users.loading && <em>Loading users...</em>}
                {users.error && <span className="text-danger">ERROR: {users.error}</span>}
                {users.items &&
                    <ul>
                        {users.items.map((user, index) =>
                            <li key={user.id}>
                                {user.firstName + ' ' + user.lastName}
                                {
                                    user.deleting ? <em> - Deleting...</em>
                                    : user.deleteError ? <span className="text-danger"> - ERROR: {user.deleteError}</span>
                                    : <span> - <a onClick={this.handleDeleteUser(user.id)}>Delete</a></span>
                                }
                            </li>
                        )}
                    </ul>
                }
                <p>
                    <Link to="/login">Logout</Link>
                </p>
            </div>
        );
    }
}
 
function mapStateToProps(state) {
    const { users, authentication } = state;
    const { user } = authentication;
    return {
        user,
        users
    };
}
 
const connectedHomePage = connect(mapStateToProps)(HomePage);
export { connectedHomePage as HomePage };
*/