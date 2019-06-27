import React from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent";
import TeamsPageHelper from "./TeamsPageHelper";

// import { Container } from "semantic-ui-react";
// import EditableTable from "../common/EditableTable";

export class TeamsPage extends AutoBindComponent {
    constructor(props, context) {
        super(props, context);

        this.state = {
            teams: []
        };
    }

    componentDidMount() {
        this.pageHelper = new TeamsPageHelper(this);
        //this.pageHelper.init();
    }

    render() {
        // const { teams: teams } = this.state;

        // const columns = [
        //     { dataField: 'id', text: 'Id' },
        //     { dataField: 'name', text: 'Name' },
        //     { dataField: 'competitionName', text: 'Competition' },
        // ];

        return (
            <h1>Teams</h1>
            // <EditableTable keyField="id" data={teams} columns={columns} ColorRow />
        );
    }
}

TeamsPage.contextType = AppContext;