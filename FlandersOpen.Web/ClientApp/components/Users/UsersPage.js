import React from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent";
import UsersPageHelper from "./UsersPageHelper";

import { Container } from "semantic-ui-react";
import EditableTable from "../common/EditableTable";

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

    render() {
        const { users } = this.state;
        const user = JSON.parse(localStorage.getItem('user'));

        const columns = [
            { dataField: "enabled", text: "Enabled" },
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
                    <EditableTable keyField="id" data={users} columns={columns} ColorRow />
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