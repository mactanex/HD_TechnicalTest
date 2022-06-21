import React from 'react';
import './../index.css';

import { styled } from '@mui/material/styles';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Typography from '@mui/material/Typography';
import ButtonBase from '@mui/material/ButtonBase';

import Moment from 'moment';

const Img = styled('img')({
    margin: 'auto',
    display: 'block',
    maxWidth: '100%',
    maxHeight: '100%',
  });

export default class SearchItem extends React.Component{
    
    render() {
        return (
            <Paper elevation={3} 
                sx={{
                    p: 2,
                    margin: 'auto',
                    maxWidth: 750,
                    flexGrow: 1,
                    backgroundColor:'ghostwhite',
                }}
                >
                    <Grid container spacing={2}>
                        <Grid item>
                        {
                            <ButtonBase sx={{ width: 64, height: 64 }}>
                             <Img key={this.props.item.author.id} src={this.props.item.author.profile_image_url} alt='' />
                             </ButtonBase>
                        }
                        </Grid>
                        <Grid item xs={12} sm container>
                            <Grid item xs container direction="column" spacing={2}>
                                <Grid item xs>
                                    <Typography gutterBottom variant="subtitle1" component="div">
                                        {this.props.item.author.name}
                                    </Typography>
                                    <Typography variant="body2" gutterBottom>
                                        {this.props.item.tweetContent}
                                    </Typography>
                                    <Typography variant="body2" color="text.secondary">
                                        {Moment(this.props.item.createdAt).format('d. MMM yyyy')}
                                    </Typography>
                                </Grid>
                                <Grid item>
                                </Grid>
                            </Grid>

                        </Grid>
                        <Grid item>
                            
                             {this.props.item.media ? ( this.props.item.media.map(media => ( <ButtonBase key={media.media_key} sx={{ width: 128, height: 128 }}><Img  src={media.url} alt='' /></ButtonBase>)) ) : ""}

                        </Grid>
                    </Grid>
                </Paper>
        ); 
      }
}