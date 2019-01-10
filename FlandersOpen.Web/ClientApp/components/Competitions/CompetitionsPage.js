import React from "react";
import { AppContext } from "../common/AppContext";
import AutoBindComponent from "../common/AutobindComponent";
import CompetitionsPageHelper from "./CompetitionsPageHelper";
import BootstrapTable from 'react-bootstrap-table-next';

import Loader from "../common/Loader";

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

    handleOnDelete(userId) {
        return function(e){
            this.pageHelper.deleteUser(userId);
        }
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
            <div className="col-md-6 col-md-offset-3">
                <h1>Competitions</h1>
                <BootstrapTable keyField="id" bootstrap4 striped data={ competitions } columns={ columns } />
            </div>
        );
    }
}

export default React.forwardRef((props, ref) => (
    <AppContext.Consumer>
        {appContext => <CompetitionsPage {...props} appContext={appContext} ref={ref} />}
    </AppContext.Consumer>
));