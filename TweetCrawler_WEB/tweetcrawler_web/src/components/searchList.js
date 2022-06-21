import React from 'react';
import './../index.css';
import SearchItem from './searchItem';
import Grid from '@mui/material/Grid';
export default class SearchList extends React.Component{
    render() {
        return (
          <Grid >
            {this.props.items.map(item => (
              <SearchItem item={item}/>
            ))}
          </Grid>
        );
      }
}