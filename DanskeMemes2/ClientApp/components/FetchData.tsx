import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FormState {
    fileName: string,
    title: string,
    description: string,
};

export class FetchData extends React.Component<RouteComponentProps<{}>, FormState> {
    constructor() {
        super();
        this.state = {
            fileName: '',
            title: '',
            description: '',
        }
    }
    
    onChange = (e: React.SyntheticEvent<EventTarget>) => {
        const input = e.target as HTMLInputElement;
        this.setState({
            fileName: input.value,
            title: input.value,
            description: input.value,
        })
    }

    onSubmit = () => {}
    

    public render() {
        return (
            <div>
                <h3>This is my stupid test form.</h3>
                <p>Try uploading a meme, we'll see what happens i guess </p>
                <form encType="multipart/form-data" onSubmit={this.onSubmit}>
                    <input type="file" name="fileName" value={this.state.fileName} onChange={this.onChange}></input>
                    <input type="text" name="title" defaultValue="Title"></input>
                    <input type="text" name="description" defaultValue="Description"></input>
            </form>
            </div>
        )
    }
}