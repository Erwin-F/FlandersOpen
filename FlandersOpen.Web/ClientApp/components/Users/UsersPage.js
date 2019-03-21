import React from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent";
import UsersPageHelper from "./UsersPageHelper";
import BootstrapTable from 'react-bootstrap-table-next';

import { Container } from "semantic-ui-react";

export class UsersPage extends AutoBindComponent {
    constructor(props, context) {
        super(props, context);

        this.state = {
            users: []
        };
    }

    componentDidMount() {
        this.pageHelper = new UsersPageHelper(this);
        this.pageHelper.init();
    }

    handleOnDelete(userId) {
        return function(e){
            this.pageHelper.deleteUser(userId);
        }
    }

    render() {
        const { users } = this.state;
        const user = JSON.parse(localStorage.getItem('user'));

        const columns = [
            { dataField: 'firstname', text: 'First name' },
            { dataField: 'lastname', text: 'Last name' },
            { dataField: 'username', text: 'Username' },
            { dataField: 'id', text: 'Id' },
        ];

        return (
            <Container>
                <div>
                    <h1>Hi {user.firstname}!</h1>
                    <h3>All registered users:</h3>
                    <BootstrapTable keyField="id" bootstrap4 striped data={ users } columns={ columns } />

                    {/* <ul>
                        {users.map((u, index) =>
                            <li key={u.id}>
                                {u.firstname + ' ' + u.lastname}
                                <span> - <a onClick={this.handleOnDelete(u.id)}>Delete</a></span>
                            </li>
                        )}
                    </ul> */}

                </div>
            </Container>
        );
    }
}

export default React.forwardRef((props, ref) => (
    <AppContext.Consumer>
        {appContext => <UsersPage {...props} appContext={appContext} ref={ref} />}
    </AppContext.Consumer>
));