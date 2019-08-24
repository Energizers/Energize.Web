import React from 'react';

export default class WIP extends React.Component {
    displayName = WIP.name;

    render() {
        return (
            <div className='not-found'>
                <img src='./img/volta/warning.png' alt='error' width='25%' style={{minWidth: '200px'}}/><br />
                WORK IN<br/>
                PROGRESS
            </div>
        );
    }
}