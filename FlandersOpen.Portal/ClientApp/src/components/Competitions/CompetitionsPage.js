import React, { Fragment } from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent";
import CompetitionsPageHelper from "./CompetitionsPageHelper";

import Table from "../common/Table";
import Loader from "../common/Loader";

// import { Container } from "semantic-ui-react";
// import EditableTable from "../common/EditableTable";

export class CompetitionsPage extends AutoBindComponent {
    constructor(props, context) {
        super(props, context);

        this.state = {
            competitions: []
        };
    }

    componentDidMount() {
        this.pageHelper = new CompetitionsPageHelper(this);
        this.pageHelper.init();
    }

    handleOnDelete(competitionId) {
        return function (e) {
            this.pageHelper.deleteCompetition(competitionId);
        };
    }

    handleOnAddClick(){

    }

    render() {
        const ajaxCounter = this.context.ajaxCounter;


        const { competitions: competitions } = this.state;

        const columns = [
            { dataField: 'id', text: 'Id' },
            { dataField: 'name', text: 'Name' },
            { dataField: 'shortName', text: 'Short name' },
            { dataField: 'color', text: 'Color' }
        ];

        return (
            <Fragment>
                <h1>Competitions</h1><br/>
                {ajaxCounter > 0 ? <Loader /> :
                <Table 
                    keyField="id"
                    items={competitions}
                    columns={columns}
                    ColorRow                    
                />}
            </Fragment>
            // <EditableTable
            //     keyField="id"
            //     data={competitions}
            //     columns={columns}
            //     ColorRow
            // />
        );
    }
}

CompetitionsPage.contextType = AppContext;