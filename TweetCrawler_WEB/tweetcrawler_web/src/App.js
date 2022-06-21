import React from 'react';
import ReactDOM from 'react-dom/client';
import SearchList from './components/searchList';
import './index.css';
import { NavigateNext } from '@mui/icons-material';

import { Container } from '@mui/system';
import { Checkbox, Button, TextField, FormControlLabel, Grid, Pagination } from '@mui/material';

export default class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            searchTerm:"",
            withImage: false,
            resultCount: 0,
            nextToken: "",
            tweets: []
        };
        this.handlePageChange = this.handlePageChange.bind(this);
        this.handleSearchChange = this.handleSearchChange.bind(this);
        this.handleCheckboxChange = this.handleCheckboxChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handlePageChange(e) {
        if(this.state.withImage) {
            this.searchTwitterWithImages();
        } else {
            this.searchTwitter();
            
        }
    }

    handleSearchChange(e) {
        this.setState({ searchTerm: e.target.value });
    }

    handleCheckboxChange(e) {
        this.setState(({ withImage,tweets }) => (
            {
                withImage: !withImage,
                tweets:  tweets.filter(x => x.media.length > 0 )
            }
        ));
    }

    handleSubmit(e) {
        e.preventDefault();
        if(this.state.withImage) {
            this.searchTwitterWithImages();
        } else {
            this.searchTwitter();
            
        }
    }

    searchTwitter(nextToken = false) {
        if (this.state.searchTerm.length === 0) {
            return;
        }
        fetch("https://localhost:44385/api/tweet/search?searchTerm="+this.state.searchTerm + (nextToken ? "&nextToken="+this.state.nextToken : ""), {
            "method": "GET"
        })
        .then(response => response.json())
        .then(response => {
            
            this.setState({
                resultCount: response.result_count,
                nextToken: response.next_token,
                tweets: response.tweets

            })
        })
        .catch(err => { console.log(err); 
        });
    }

    searchTwitterWithImages(nextToken = false) {
        if (this.state.searchTerm.length === 0) {
            return;
        }
        fetch("https://localhost:44385/api/tweet/searchwithimage?searchTerm="+this.state.searchTerm + (nextToken ? "&nextToken="+this.state.nextToken : ""), {
            "method": "GET"
        })
        .then(response => response.json())
        .then(response => {
            this.setState({
                resultCount: response.result_count,
                nextToken: response.next_token,
                tweets: response.tweets.filter(x => x.media.length > 0 )

            })
        })
        .catch(err => { console.log(err); 
        });
    }

    render() { 
        return ( 
            <Container maxWidth="sm">
                <h1><span className="blue">TWEET</span><span className="orange">CRAWLER</span></h1> 
                <Grid container justifyContent="center">
                    <Grid item>
                        <TextField id="search-term" label="Search" variant="outlined"  onChange={this.handleSearchChange} value={this.state.searchTerm}/>
                    </Grid>
                    <Grid item alignItems="stretch" style={{ display: "flex" }}>
                        <Button variant="contained" onClick={this.handleSubmit}>
                            Search
                        </Button>
                    </Grid>
                    <Grid>
                        <FormControlLabel control={<Checkbox
                            type="checkbox"
                            checked={this.state.withImage}  
                            onChange={this.handleCheckboxChange}
                        />} label="Only show tweets with images"/>
                    
                    </Grid>
                    <Grid item>
                        <SearchList items={this.state.tweets} />
                    </Grid>
                    {this.state.tweets.length > 0 && <Button variant="contained" onClick={this.handlePageChange} endIcon={<NavigateNext />}>
                        Next 
                    </Button>}
                </Grid>
            </Container> 
        ); 
    } 
} 