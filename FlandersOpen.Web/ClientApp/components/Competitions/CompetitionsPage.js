import React from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent";
import CompetitionsPageHelper from "./CompetitionsPageHelper";

import { Container } from "semantic-ui-react";
import EditableTable from "../common/EditableTable";

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
        const { competitions: competitions } = this.state;

        const columns = [
            { dataField: 'id', text: 'Id' },
            { dataField: 'name', text: 'Name' },
            { dataField: 'shortName', text: 'Short name' },
            { dataField: 'color', text: 'Color' }
        ];

        return (
            <Container>
                <h1>Competitions</h1>
                <EditableTable
                    keyField="id"
                    data={competitions}
                    columns={columns}
                    ColorRow
                />
            </Container>
        );
    }
}

export default React.forwardRef((props, ref) => (
    <AppContext.Consumer>
        {appContext => <CompetitionsPage {...props} appContext={appContext} ref={ref} />}
    </AppContext.Consumer>
));