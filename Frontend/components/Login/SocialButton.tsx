import { Component } from "react";
import SocialLogin, { ISocialLoginProps } from "react-social-login";

class SocialButton extends Component<ISocialLoginProps> {
    render() {
        return (
            <button onClick={this.props.triggerLogin} {...this.props}>
                {this.props.children}
            </button>
        );
    }
}

export default SocialLogin(SocialButton);
