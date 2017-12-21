import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FormState {
    file: File | null,
    title: string,
    description: string,
};

export class FetchData extends React.Component<RouteComponentProps<{}>, FormState> {
    constructor() {
        super();
        this.state = {
            file: null,
            title: '',
            description: '',
        }
    }

    handleChangeFile = (files: FileList | null) => {
        this.setState({
            file: files != null ? files[0] : null,
        })
    };

    handleChangeTitle = (input: HTMLInputElement) => {
        this.setState({ title: input.value})
    }

    handleChangeDescription = (input: HTMLInputElement) => {
        this.setState({description: input.value})
    }

    onSubmit = (e: React.SyntheticEvent<EventTarget>) => {
        e.preventDefault();
        const formData = new FormData();
        formData.append("file", this.state.file as Blob);
        formData.append("title", this.state.title);
        formData.append("description", this.state.description);
        fetch('http://localhost:54487/api/meme', {
            method: 'POST',
            body: formData
        }).then(function (res) {
            if (res.ok) {
                console.log('It worked?')
            }
        });
    }   

    public render() {
        return (
            <div className="col-md-4">
                <h3>This is my stupid test form.</h3>
                <p>Try uploading a meme, we'll see what happens i guess </p>
                <form encType="multipart/form-data" onSubmit={this.onSubmit}>
                    <div className="form-group">
                        <label label="title">Title</label>
                        <input type="text" name="title" className="form-control" onChange={(e) => this.handleChangeTitle(e.target)}></input>
                    </div>
                    <div className="form-group">
                        <label label="description">Description</label>
                        <input type="text" name="description" className="form-control" onChange={(e) => this.handleChangeDescription(e.target)}></input>
                    </div>
                    <div className="form-group">
                        <label label="file">Image</label>
                        <input type="file" name="file" className="form-control" onChange={(e) => this.handleChangeFile(e.target.files)}></input>
                    </div>
                    <button type="submit" className="btn btn-default">Submit</button>
                </form>
            </div>
        )
    }
}