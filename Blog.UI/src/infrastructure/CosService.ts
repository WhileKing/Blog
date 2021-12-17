import COS from 'cos-js-sdk-v5';
import CosProviderRepository from './repository/CosProviderRepository';
import { BucketConfig } from '../domain/BucketConfig';

class CosService {
    private config: BucketConfig = { bucket: '', region: '' };
    private instance: COS = new COS({
        getAuthorization: async (options, callback) => {
            const data = await new CosProviderRepository().GetCredential();
            callback({
                SecurityToken: data.token,
                TmpSecretId: data.secretId,
                TmpSecretKey: data.secretKey,
                StartTime: data.startTime,
                ExpiredTime: data.expiredTime,
                ScopeLimit: true,
            });
        },
    });
    async multiUpload(files: File[]): Promise<string[]> {
        this.config = await new CosProviderRepository().GetConfig();
        const file = files[0];
        return new Promise<string[]>((resolve, reject) => {
            this.instance.putObject(
                {
                    Bucket: this.config.bucket,
                    Region: this.config.region,
                    Key: 'images/test.jpg',
                    Body: file,
                },
                (err, data) => {
                    if (err) {
                        reject(err);
                        return;
                    }
                    resolve([data.Location]);
                }
            );
        });
    }
}

export default new CosService();
