import React, { Fragment } from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent";
import TeamsPageHelper from "./TeamsPageHelper";

import Table from "../common/Table";
import Loader from "../common/Loader";

export class TeamsPage extends AutoBindComponent {
    constructor(props, context) {
        super(props, context);

        this.state = {
            teams: []
        };
    }

    componentDidMount() {
        this.pageHelper = new TeamsPageHelper(this);
        this.pageHelper.init();
    }

    handleOnDelete(teamId) {

    }

    handleOnAdd(){

    }

    handleOnUpdate() {

    }

    render() {
        const ajaxCounter = this.context.ajaxCounter;
        const { teams } = this.state;

        const columns = [
            { dataField: 'id', text: 'Id' },
            { dataField: 'name', text: 'Name' },
            { dataField: 'competitionName', text: 'Competition' },
        ];

        return (
            <Fragment>
            <h1>Teams</h1><br/>
                {ajaxCounter > 0 ? <Loader /> :
                <Table
                    keyField="id"
                    items={teams}
                    columns={columns}
                    ColorRow
                    onDelete={this.handleOnDelete}
                    onAdd={this.handleOnAdd}
                    onUpdate={this.handleOnUpdate}
                />}
            </Fragment>
        );
    }
}

TeamsPage.contextType = AppContext;