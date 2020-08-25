# [.gitignore (templates)](https://docs.gitlab.com/ee/api/templates/gitignores.html)
- [ ] [List .gitignore templates](https://docs.gitlab.com/ee/api/templates/gitignores.html#list-gitignore-templates) `GET /templates/gitignores`
- [ ] [Single .gitignore template](https://docs.gitlab.com/ee/api/templates/gitignores.html#single-gitignore-template) `GET /templates/gitignores/:key`

# [Access requests](https://docs.gitlab.com/ee/api/access_requests.html)
- [ ] [List access requests for a group or project](https://docs.gitlab.com/ee/api/access_requests.html#list-access-requests-for-a-group-or-project) `GET /groups/:id/access_requests`
- [ ] [List access requests for a group or project](https://docs.gitlab.com/ee/api/access_requests.html#list-access-requests-for-a-group-or-project) `GET /projects/:id/access_requests`
- [ ] [Request access to a group or project](https://docs.gitlab.com/ee/api/access_requests.html#request-access-to-a-group-or-project) `POST /groups/:id/access_requests`
- [ ] [Request access to a group or project](https://docs.gitlab.com/ee/api/access_requests.html#request-access-to-a-group-or-project) `POST /projects/:id/access_requests`
- [ ] [Approve an access request](https://docs.gitlab.com/ee/api/access_requests.html#approve-an-access-request) `PUT /groups/:id/access_requests/:user_id/approve`
- [ ] [Approve an access request](https://docs.gitlab.com/ee/api/access_requests.html#approve-an-access-request) `PUT /projects/:id/access_requests/:user_id/approve`
- [ ] [Deny an access request](https://docs.gitlab.com/ee/api/access_requests.html#deny-an-access-request) `DELETE /groups/:id/access_requests/:user_id`
- [ ] [Deny an access request](https://docs.gitlab.com/ee/api/access_requests.html#deny-an-access-request) `DELETE /projects/:id/access_requests/:user_id`

# [Appearance (application)](https://docs.gitlab.com/ee/api/appearance.html)
- [ ] [Get current appearance configuration](https://docs.gitlab.com/ee/api/appearance.html#get-current-appearance-configuration) `GET /application/appearance`
- [ ] [Change appearance configuration](https://docs.gitlab.com/ee/api/appearance.html#change-appearance-configuration) `PUT /application/appearance`

# [.gitlab-ci.yml (templates)](https://docs.gitlab.com/ee/api/templates/gitlab_ci_ymls.html)
- [ ] [List GitLab CI YAML templates](https://docs.gitlab.com/ee/api/templates/gitlab_ci_ymls.html#list-gitlab-ci-yaml-templates) `GET /templates/gitlab_ci_ymls`
- [ ] [Single GitLab CI YAML template](https://docs.gitlab.com/ee/api/templates/gitlab_ci_ymls.html#single-gitlab-ci-yaml-template) `GET /templates/gitlab_ci_ymls/:key`

# [Applications](https://docs.gitlab.com/ee/api/applications.html)
- [ ] [Create an application](https://docs.gitlab.com/ee/api/applications.html#create-an-application) `POST /applications`
- [ ] [List all applications](https://docs.gitlab.com/ee/api/applications.html#list-all-applications) `GET /applications`
- [ ] [Delete an application](https://docs.gitlab.com/ee/api/applications.html#delete-an-application) `DELETE /applications/:id`

# [Audit events](https://docs.gitlab.com/ee/api/audit_events.html)
- [ ] [Retrieve all instance audit events](https://docs.gitlab.com/ee/api/audit_events.html#retrieve-all-instance-audit-events) `GET /audit_events`
- [ ] [Retrieve single instance audit event](https://docs.gitlab.com/ee/api/audit_events.html#retrieve-single-instance-audit-event) `GET /audit_events/:id`
- [ ] [Retrieve all group audit events](https://docs.gitlab.com/ee/api/audit_events.html#retrieve-all-group-audit-events) `GET /groups/:id/audit_events`
- [ ] [Retrieve a specific group audit event](https://docs.gitlab.com/ee/api/audit_events.html#retrieve-a-specific-group-audit-event) `GET /groups/:id/audit_events/:audit_event_id`
- [ ] [Retrieve all project audit events](https://docs.gitlab.com/ee/api/audit_events.html#retrieve-all-project-audit-events) `GET /projects/:id/audit_events`
- [ ] [Retrieve a specific project audit event](https://docs.gitlab.com/ee/api/audit_events.html#retrieve-a-specific-project-audit-event) `GET /projects/:id/audit_events/:audit_event_id`

# [Avatar](https://docs.gitlab.com/ee/api/avatar.html)
- [ ] [Get a single avatar URL](https://docs.gitlab.com/ee/api/avatar.html#get-a-single-avatar-url) `GET /avatar`

# [Award emoji](https://docs.gitlab.com/ee/api/award_emoji.html)
- [ ] [List an awardable’s award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#list-an-awardables-award-emoji) `GET /projects/:id/issues/:issue_iid/award_emoji`
- [ ] [List an awardable’s award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#list-an-awardables-award-emoji) `GET /projects/:id/merge_requests/:merge_request_iid/award_emoji`
- [ ] [List an awardable’s award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#list-an-awardables-award-emoji) `GET /projects/:id/snippets/:snippet_id/award_emoji`
- [ ] [Get single award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#get-single-award-emoji) `GET /projects/:id/issues/:issue_iid/award_emoji/:award_id`
- [ ] [Get single award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#get-single-award-emoji) `GET /projects/:id/merge_requests/:merge_request_iid/award_emoji/:award_id`
- [ ] [Get single award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#get-single-award-emoji) `GET /projects/:id/snippets/:snippet_id/award_emoji/:award_id`
- [ ] [Award a new emoji](https://docs.gitlab.com/ee/api/award_emoji.html#award-a-new-emoji) `POST /projects/:id/issues/:issue_iid/award_emoji`
- [ ] [Award a new emoji](https://docs.gitlab.com/ee/api/award_emoji.html#award-a-new-emoji) `POST /projects/:id/merge_requests/:merge_request_iid/award_emoji`
- [ ] [Award a new emoji](https://docs.gitlab.com/ee/api/award_emoji.html#award-a-new-emoji) `POST /projects/:id/snippets/:snippet_id/award_emoji`
- [ ] [Delete an award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#delete-an-award-emoji) `DELETE /projects/:id/issues/:issue_iid/award_emoji/:award_id`
- [ ] [Delete an award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#delete-an-award-emoji) `DELETE /projects/:id/merge_requests/:merge_request_iid/award_emoji/:award_id`
- [ ] [Delete an award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#delete-an-award-emoji) `DELETE /projects/:id/snippets/:snippet_id/award_emoji/:award_id`
- [ ] [List a comment’s award emoji](https://docs.gitlab.com/ee/api/award_emoji.html#list-a-comments-award-emoji) `GET /projects/:id/issues/:issue_iid/notes/:note_id/award_emoji`
- [ ] [Get an award emoji for a comment](https://docs.gitlab.com/ee/api/award_emoji.html#get-an-award-emoji-for-a-comment) `GET /projects/:id/issues/:issue_iid/notes/:note_id/award_emoji/:award_id`
- [ ] [Award a new emoji on a comment](https://docs.gitlab.com/ee/api/award_emoji.html#award-a-new-emoji-on-a-comment) `POST /projects/:id/issues/:issue_iid/notes/:note_id/award_emoji`
- [ ] [Delete an award emoji from a comment](https://docs.gitlab.com/ee/api/award_emoji.html#delete-an-award-emoji-from-a-comment) `DELETE /projects/:id/issues/:issue_iid/notes/:note_id/award_emoji/:award_id`

# [Badges (project)](https://docs.gitlab.com/ee/api/project_badges.html)
- [ ] [List all badges of a project](https://docs.gitlab.com/ee/api/project_badges.html#list-all-badges-of-a-project) `GET /projects/:id/badges`
- [ ] [Get a badge of a project](https://docs.gitlab.com/ee/api/project_badges.html#get-a-badge-of-a-project) `GET /projects/:id/badges/:badge_id`
- [ ] [Add a badge to a project](https://docs.gitlab.com/ee/api/project_badges.html#add-a-badge-to-a-project) `POST /projects/:id/badges`
- [ ] [Edit a badge of a project](https://docs.gitlab.com/ee/api/project_badges.html#edit-a-badge-of-a-project) `PUT /projects/:id/badges/:badge_id`
- [ ] [Remove a badge from a project](https://docs.gitlab.com/ee/api/project_badges.html#remove-a-badge-from-a-project) `DELETE /projects/:id/badges/:badge_id`
- [ ] [Preview a badge from a project](https://docs.gitlab.com/ee/api/project_badges.html#preview-a-badge-from-a-project) `GET /projects/:id/badges/render`

# [Badges (group)](https://docs.gitlab.com/ee/api/group_badges.html)
- [ ] [List all badges of a group](https://docs.gitlab.com/ee/api/group_badges.html#list-all-badges-of-a-group) `GET /groups/:id/badges`
- [ ] [Get a badge of a group](https://docs.gitlab.com/ee/api/group_badges.html#get-a-badge-of-a-group) `GET /groups/:id/badges/:badge_id`
- [ ] [Add a badge to a group](https://docs.gitlab.com/ee/api/group_badges.html#add-a-badge-to-a-group) `POST /groups/:id/badges`
- [ ] [Edit a badge of a group](https://docs.gitlab.com/ee/api/group_badges.html#edit-a-badge-of-a-group) `PUT /groups/:id/badges/:badge_id`
- [ ] [Remove a badge from a group](https://docs.gitlab.com/ee/api/group_badges.html#remove-a-badge-from-a-group) `DELETE /groups/:id/badges/:badge_id`
- [ ] [Preview a badge from a group](https://docs.gitlab.com/ee/api/group_badges.html#preview-a-badge-from-a-group) `GET /groups/:id/badges/render`

# [Branches](https://docs.gitlab.com/ee/api/branches.html)
- [ ] [List repository branches](https://docs.gitlab.com/ee/api/branches.html#list-repository-branches) `GET /projects/:id/repository/branches`
- [ ] [Get single repository branch](https://docs.gitlab.com/ee/api/branches.html#get-single-repository-branch) `GET /projects/:id/repository/branches/:branch`
- [ ] [Create repository branch](https://docs.gitlab.com/ee/api/branches.html#create-repository-branch) `POST /projects/:id/repository/branches`
- [ ] [Delete repository branch](https://docs.gitlab.com/ee/api/branches.html#delete-repository-branch) `DELETE /projects/:id/repository/branches/:branch`
- [ ] [Delete merged branches](https://docs.gitlab.com/ee/api/branches.html#delete-merged-branches) `DELETE /projects/:id/repository/merged_branches`

# [Broadcast messages](https://docs.gitlab.com/ee/api/broadcast_messages.html)
- [ ] [Get all broadcast messages](https://docs.gitlab.com/ee/api/broadcast_messages.html#get-all-broadcast-messages) `GET /broadcast_messages`
- [ ] [Get a specific broadcast message](https://docs.gitlab.com/ee/api/broadcast_messages.html#get-a-specific-broadcast-message) `GET /broadcast_messages/:id`
- [ ] [Create a broadcast message](https://docs.gitlab.com/ee/api/broadcast_messages.html#create-a-broadcast-message) `POST /broadcast_messages`
- [ ] [Update a broadcast message](https://docs.gitlab.com/ee/api/broadcast_messages.html#update-a-broadcast-message) `PUT /broadcast_messages/:id`
- [ ] [Delete a broadcast message](https://docs.gitlab.com/ee/api/broadcast_messages.html#delete-a-broadcast-message) `DELETE /broadcast_messages/:id`

# [Clusters (project)](https://docs.gitlab.com/ee/api/project_clusters.html)
- [ ] [List project clusters](https://docs.gitlab.com/ee/api/project_clusters.html#list-project-clusters) `GET /projects/:id/clusters`
- [ ] [Get a single project cluster](https://docs.gitlab.com/ee/api/project_clusters.html#get-a-single-project-cluster) `GET /projects/:id/clusters/:cluster_id`
- [ ] [Add existing cluster to project](https://docs.gitlab.com/ee/api/project_clusters.html#add-existing-cluster-to-project) `POST /projects/:id/clusters/user`
- [ ] [Edit project cluster](https://docs.gitlab.com/ee/api/project_clusters.html#edit-project-cluster) `PUT /projects/:id/clusters/:cluster_id`
- [ ] [Delete project cluster](https://docs.gitlab.com/ee/api/project_clusters.html#delete-project-cluster) `DELETE /projects/:id/clusters/:cluster_id`

# [Clusters (group)](https://docs.gitlab.com/ee/api/group_clusters.html)
- [ ] [List group clusters](https://docs.gitlab.com/ee/api/group_clusters.html#list-group-clusters) `GET /groups/:id/clusters`
- [ ] [Get a single group cluster](https://docs.gitlab.com/ee/api/group_clusters.html#get-a-single-group-cluster) `GET /groups/:id/clusters/:cluster_id`
- [ ] [Add existing cluster to group](https://docs.gitlab.com/ee/api/group_clusters.html#add-existing-cluster-to-group) `POST /groups/:id/clusters/user`
- [ ] [Edit group cluster](https://docs.gitlab.com/ee/api/group_clusters.html#edit-group-cluster) `PUT /groups/:id/clusters/:cluster_id`
- [ ] [Delete group cluster](https://docs.gitlab.com/ee/api/group_clusters.html#delete-group-cluster) `DELETE /groups/:id/clusters/:cluster_id`

# [Clusters (instance)](https://docs.gitlab.com/ee/api/instance_clusters.html)
- [ ] [List instance clusters](https://docs.gitlab.com/ee/api/instance_clusters.html#list-instance-clusters) `GET /admin/clusters`
- [ ] [Get a single instance cluster](https://docs.gitlab.com/ee/api/instance_clusters.html#get-a-single-instance-cluster) `GET /admin/clusters/:cluster_id`
- [ ] [Add existing instance cluster](https://docs.gitlab.com/ee/api/instance_clusters.html#add-existing-instance-cluster) `POST /admin/clusters/add`
- [ ] [Edit instance cluster](https://docs.gitlab.com/ee/api/instance_clusters.html#edit-instance-cluster) `PUT /admin/clusters/:cluster_id`
- [ ] [Delete instance cluster](https://docs.gitlab.com/ee/api/instance_clusters.html#delete-instance-cluster) `DELETE /admin/clusters/:cluster_id`

# [Commits](https://docs.gitlab.com/ee/api/commits.html)
- [ ] [List repository commits](https://docs.gitlab.com/ee/api/commits.html#list-repository-commits) `GET /projects/:id/repository/commits`
- [ ] [Create a commit with multiple files and actions](https://docs.gitlab.com/ee/api/commits.html#create-a-commit-with-multiple-files-and-actions) `POST /projects/:id/repository/commits`
- [ ] [Get a single commit](https://docs.gitlab.com/ee/api/commits.html#get-a-single-commit) `GET /projects/:id/repository/commits/:sha`
- [ ] [Get references a commit is pushed to](https://docs.gitlab.com/ee/api/commits.html#get-references-a-commit-is-pushed-to) `GET /projects/:id/repository/commits/:sha/refs`
- [ ] [Cherry pick a commit](https://docs.gitlab.com/ee/api/commits.html#cherry-pick-a-commit) `POST /projects/:id/repository/commits/:sha/cherry_pick`
- [ ] [Revert a commit](https://docs.gitlab.com/ee/api/commits.html#revert-a-commit) `POST /projects/:id/repository/commits/:sha/revert`
- [ ] [Get the diff of a commit](https://docs.gitlab.com/ee/api/commits.html#get-the-diff-of-a-commit) `GET /projects/:id/repository/commits/:sha/diff`
- [ ] [Get the comments of a commit](https://docs.gitlab.com/ee/api/commits.html#get-the-comments-of-a-commit) `GET /projects/:id/repository/commits/:sha/comments`
- [ ] [Post comment to commit](https://docs.gitlab.com/ee/api/commits.html#post-comment-to-commit) `POST /projects/:id/repository/commits/:sha/comments`
- [ ] [Get the discussions of a commit](https://docs.gitlab.com/ee/api/commits.html#get-the-discussions-of-a-commit) `GET /projects/:id/repository/commits/:sha/discussions`
- [ ] [List the statuses of a commit](https://docs.gitlab.com/ee/api/commits.html#list-the-statuses-of-a-commit) `GET /projects/:id/repository/commits/:sha/statuses`
- [ ] [Post the build status to a commit](https://docs.gitlab.com/ee/api/commits.html#post-the-build-status-to-a-commit) `POST /projects/:id/statuses/:sha`
- [ ] [List Merge Requests associated with a commit](https://docs.gitlab.com/ee/api/commits.html#list-merge-requests-associated-with-a-commit) `GET /projects/:id/repository/commits/:sha/merge_requests`
- [ ] [Get GPG signature of a commit](https://docs.gitlab.com/ee/api/commits.html#get-gpg-signature-of-a-commit) `GET /projects/:id/repository/commits/:sha/signature`

# [Container Registry](https://docs.gitlab.com/ee/api/container_registry.html)
- [ ] [Within a project](https://docs.gitlab.com/ee/api/container_registry.html#within-a-project) `GET /projects/:id/registry/repositories`
- [ ] [Within a group](https://docs.gitlab.com/ee/api/container_registry.html#within-a-group) `GET /groups/:id/registry/repositories`
- [ ] [Delete registry repository](https://docs.gitlab.com/ee/api/container_registry.html#delete-registry-repository) `DELETE /projects/:id/registry/repositories/:repository_id`
- [ ] [Within a project](https://docs.gitlab.com/ee/api/container_registry.html#within-a-project-1) `GET /projects/:id/registry/repositories/:repository_id/tags`
- [ ] [Get details of a registry repository tag](https://docs.gitlab.com/ee/api/container_registry.html#get-details-of-a-registry-repository-tag) `GET /projects/:id/registry/repositories/:repository_id/tags/:tag_name`
- [ ] [Delete a registry repository tag](https://docs.gitlab.com/ee/api/container_registry.html#delete-a-registry-repository-tag) `DELETE /projects/:id/registry/repositories/:repository_id/tags/:tag_name`
- [ ] [Delete registry repository tags in bulk](https://docs.gitlab.com/ee/api/container_registry.html#delete-registry-repository-tags-in-bulk) `DELETE /projects/:id/registry/repositories/:repository_id/tags`

# [Custom attributes](https://docs.gitlab.com/ee/api/custom_attributes.html)
- [ ] [List custom attributes](https://docs.gitlab.com/ee/api/custom_attributes.html#list-custom-attributes) `GET /users/:id/custom_attributes`
- [ ] [List custom attributes](https://docs.gitlab.com/ee/api/custom_attributes.html#list-custom-attributes) `GET /groups/:id/custom_attributes`
- [ ] [List custom attributes](https://docs.gitlab.com/ee/api/custom_attributes.html#list-custom-attributes) `GET /projects/:id/custom_attributes`
- [ ] [Single custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#single-custom-attribute) `GET /users/:id/custom_attributes/:key`
- [ ] [Single custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#single-custom-attribute) `GET /groups/:id/custom_attributes/:key`
- [ ] [Single custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#single-custom-attribute) `GET /projects/:id/custom_attributes/:key`
- [ ] [Set custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#set-custom-attribute) `PUT /users/:id/custom_attributes/:key`
- [ ] [Set custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#set-custom-attribute) `PUT /groups/:id/custom_attributes/:key`
- [ ] [Set custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#set-custom-attribute) `PUT /projects/:id/custom_attributes/:key`
- [ ] [Delete custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#delete-custom-attribute) `DELETE /users/:id/custom_attributes/:key`
- [ ] [Delete custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#delete-custom-attribute) `DELETE /groups/:id/custom_attributes/:key`
- [ ] [Delete custom attribute](https://docs.gitlab.com/ee/api/custom_attributes.html#delete-custom-attribute) `DELETE /projects/:id/custom_attributes/:key`

# [Dashboard annotations](https://docs.gitlab.com/ee/api/metrics_dashboard_annotations.html)
- [ ] [Create a new annotation](https://docs.gitlab.com/ee/api/metrics_dashboard_annotations.html#create-a-new-annotation) `POST /environments/:id/metrics_dashboard/annotations/`
- [ ] [Create a new annotation](https://docs.gitlab.com/ee/api/metrics_dashboard_annotations.html#create-a-new-annotation) `POST /clusters/:id/metrics_dashboard/annotations/`

# [Dependencies](https://docs.gitlab.com/ee/api/dependencies.html)
- [ ] [List project dependencies](https://docs.gitlab.com/ee/api/dependencies.html#list-project-dependencies) `GET /projects/:id/dependencies`

# [Deploy keys](https://docs.gitlab.com/ee/api/deploy_keys.html)
- [ ] [List all deploy keys](https://docs.gitlab.com/ee/api/deploy_keys.html#list-all-deploy-keys) `GET /deploy_keys`
- [ ] [List project deploy keys](https://docs.gitlab.com/ee/api/deploy_keys.html#list-project-deploy-keys) `GET /projects/:id/deploy_keys`
- [ ] [Single deploy key](https://docs.gitlab.com/ee/api/deploy_keys.html#single-deploy-key) `GET /projects/:id/deploy_keys/:key_id`
- [ ] [Add deploy key](https://docs.gitlab.com/ee/api/deploy_keys.html#add-deploy-key) `POST /projects/:id/deploy_keys`
- [ ] [Update deploy key](https://docs.gitlab.com/ee/api/deploy_keys.html#update-deploy-key) `PUT /projects/:id/deploy_keys/:key_id`
- [ ] [Delete deploy key](https://docs.gitlab.com/ee/api/deploy_keys.html#delete-deploy-key) `DELETE /projects/:id/deploy_keys/:key_id`

# [Deployments](https://docs.gitlab.com/ee/api/deployments.html)
- [ ] [List project deployments](https://docs.gitlab.com/ee/api/deployments.html#list-project-deployments) `GET /projects/:id/deployments`
- [ ] [Get a specific deployment](https://docs.gitlab.com/ee/api/deployments.html#get-a-specific-deployment) `GET /projects/:id/deployments/:deployment_id`
- [ ] [Create a deployment](https://docs.gitlab.com/ee/api/deployments.html#create-a-deployment) `POST /projects/:id/deployments`
- [ ] [Updating a deployment](https://docs.gitlab.com/ee/api/deployments.html#updating-a-deployment) `PUT /projects/:id/deployments/:deployment_id`
- [ ] [List of merge requests associated with a deployment](https://docs.gitlab.com/ee/api/deployments.html#list-of-merge-requests-associated-with-a-deployment) `GET /projects/:id/deployments/:deployment_id/merge_requests`

# [Discussions](https://docs.gitlab.com/ee/api/discussions.html)
- [ ] [List project issue discussion items](https://docs.gitlab.com/ee/api/discussions.html#list-project-issue-discussion-items) `GET /projects/:id/issues/:issue_iid/discussions`
- [ ] [Get single issue discussion item](https://docs.gitlab.com/ee/api/discussions.html#get-single-issue-discussion-item) `GET /projects/:id/issues/:issue_iid/discussions/:discussion_id`
- [ ] [Create new issue thread](https://docs.gitlab.com/ee/api/discussions.html#create-new-issue-thread) `POST /projects/:id/issues/:issue_iid/discussions`
- [ ] [Add note to existing issue thread](https://docs.gitlab.com/ee/api/discussions.html#add-note-to-existing-issue-thread) `POST /projects/:id/issues/:issue_iid/discussions/:discussion_id/notes`
- [ ] [Modify existing issue thread note](https://docs.gitlab.com/ee/api/discussions.html#modify-existing-issue-thread-note) `PUT /projects/:id/issues/:issue_iid/discussions/:discussion_id/notes/:note_id`
- [ ] [Delete an issue thread note](https://docs.gitlab.com/ee/api/discussions.html#delete-an-issue-thread-note) `DELETE /projects/:id/issues/:issue_iid/discussions/:discussion_id/notes/:note_id`
- [ ] [List project snippet discussion items](https://docs.gitlab.com/ee/api/discussions.html#list-project-snippet-discussion-items) `GET /projects/:id/snippets/:snippet_id/discussions`
- [ ] [Get single snippet discussion item](https://docs.gitlab.com/ee/api/discussions.html#get-single-snippet-discussion-item) `GET /projects/:id/snippets/:snippet_id/discussions/:discussion_id`
- [ ] [Create new snippet thread](https://docs.gitlab.com/ee/api/discussions.html#create-new-snippet-thread) `POST /projects/:id/snippets/:snippet_id/discussions`
- [ ] [Add note to existing snippet thread](https://docs.gitlab.com/ee/api/discussions.html#add-note-to-existing-snippet-thread) `POST /projects/:id/snippets/:snippet_id/discussions/:discussion_id/notes`
- [ ] [Modify existing snippet thread note](https://docs.gitlab.com/ee/api/discussions.html#modify-existing-snippet-thread-note) `PUT /projects/:id/snippets/:snippet_id/discussions/:discussion_id/notes/:note_id`
- [ ] [Delete a snippet thread note](https://docs.gitlab.com/ee/api/discussions.html#delete-a-snippet-thread-note) `DELETE /projects/:id/snippets/:snippet_id/discussions/:discussion_id/notes/:note_id`
- [ ] [List group epic discussion items](https://docs.gitlab.com/ee/api/discussions.html#list-group-epic-discussion-items) `GET /groups/:id/epics/:epic_id/discussions`
- [ ] [Get single epic discussion item](https://docs.gitlab.com/ee/api/discussions.html#get-single-epic-discussion-item) `GET /groups/:id/epics/:epic_id/discussions/:discussion_id`
- [ ] [Create new epic thread](https://docs.gitlab.com/ee/api/discussions.html#create-new-epic-thread) `POST /groups/:id/epics/:epic_id/discussions`
- [ ] [Add note to existing epic thread](https://docs.gitlab.com/ee/api/discussions.html#add-note-to-existing-epic-thread) `POST /groups/:id/epics/:epic_id/discussions/:discussion_id/notes`
- [ ] [Modify existing epic thread note](https://docs.gitlab.com/ee/api/discussions.html#modify-existing-epic-thread-note) `PUT /groups/:id/epics/:epic_id/discussions/:discussion_id/notes/:note_id`
- [ ] [Delete an epic thread note](https://docs.gitlab.com/ee/api/discussions.html#delete-an-epic-thread-note) `DELETE /groups/:id/epics/:epic_id/discussions/:discussion_id/notes/:note_id`
- [ ] [List project merge request discussion items](https://docs.gitlab.com/ee/api/discussions.html#list-project-merge-request-discussion-items) `GET /projects/:id/merge_requests/:merge_request_iid/discussions`
- [ ] [Get single merge request discussion item](https://docs.gitlab.com/ee/api/discussions.html#get-single-merge-request-discussion-item) `GET /projects/:id/merge_requests/:merge_request_iid/discussions/:discussion_id`
- [ ] [Create new merge request thread](https://docs.gitlab.com/ee/api/discussions.html#create-new-merge-request-thread) `POST /projects/:id/merge_requests/:merge_request_iid/discussions`
- [ ] [Resolve a merge request thread](https://docs.gitlab.com/ee/api/discussions.html#resolve-a-merge-request-thread) `PUT /projects/:id/merge_requests/:merge_request_iid/discussions/:discussion_id`
- [ ] [Add note to existing merge request thread](https://docs.gitlab.com/ee/api/discussions.html#add-note-to-existing-merge-request-thread) `POST /projects/:id/merge_requests/:merge_request_iid/discussions/:discussion_id/notes`
- [ ] [Modify an existing merge request thread note](https://docs.gitlab.com/ee/api/discussions.html#modify-an-existing-merge-request-thread-note) `PUT /projects/:id/merge_requests/:merge_request_iid/discussions/:discussion_id/notes/:note_id`
- [ ] [Delete a merge request thread note](https://docs.gitlab.com/ee/api/discussions.html#delete-a-merge-request-thread-note) `DELETE /projects/:id/merge_requests/:merge_request_iid/discussions/:discussion_id/notes/:note_id`
- [ ] [List project commit discussion items](https://docs.gitlab.com/ee/api/discussions.html#list-project-commit-discussion-items) `GET /projects/:id/commits/:commit_id/discussions`
- [ ] [Get single commit discussion item](https://docs.gitlab.com/ee/api/discussions.html#get-single-commit-discussion-item) `GET /projects/:id/commits/:commit_id/discussions/:discussion_id`
- [ ] [Create new commit thread](https://docs.gitlab.com/ee/api/discussions.html#create-new-commit-thread) `POST /projects/:id/commits/:commit_id/discussions`
- [ ] [Add note to existing commit thread](https://docs.gitlab.com/ee/api/discussions.html#add-note-to-existing-commit-thread) `POST /projects/:id/commits/:commit_id/discussions/:discussion_id/notes`
- [ ] [Modify an existing commit thread note](https://docs.gitlab.com/ee/api/discussions.html#modify-an-existing-commit-thread-note) `PUT /projects/:id/commits/:commit_id/discussions/:discussion_id/notes/:note_id`
- [ ] [Delete a commit thread note](https://docs.gitlab.com/ee/api/discussions.html#delete-a-commit-thread-note) `DELETE /projects/:id/commits/:commit_id/discussions/:discussion_id/notes/:note_id`

# [Dockerfile (templates)](https://docs.gitlab.com/ee/api/templates/dockerfiles.html)
- [ ] [List Dockerfile templates](https://docs.gitlab.com/ee/api/templates/dockerfiles.html#list-dockerfile-templates) `GET /templates/dockerfiles`
- [ ] [Single Dockerfile template](https://docs.gitlab.com/ee/api/templates/dockerfiles.html#single-dockerfile-template) `GET /templates/dockerfiles/:key`

# [Environments](https://docs.gitlab.com/ee/api/environments.html)
- [ ] [List environments](https://docs.gitlab.com/ee/api/environments.html#list-environments) `GET /projects/:id/environments`
- [ ] [Get a specific environment](https://docs.gitlab.com/ee/api/environments.html#get-a-specific-environment) `GET /projects/:id/environments/:environment_id`
- [ ] [Create a new environment](https://docs.gitlab.com/ee/api/environments.html#create-a-new-environment) `POST /projects/:id/environments`
- [ ] [Edit an existing environment](https://docs.gitlab.com/ee/api/environments.html#edit-an-existing-environment) `PUT /projects/:id/environments/:environments_id`
- [ ] [Delete an environment](https://docs.gitlab.com/ee/api/environments.html#delete-an-environment) `DELETE /projects/:id/environments/:environment_id`
- [ ] [Stop an environment](https://docs.gitlab.com/ee/api/environments.html#stop-an-environment) `POST /projects/:id/environments/:environment_id/stop`

# [Epics](https://docs.gitlab.com/ee/api/epics.html)
- [ ] [List epics for a group](https://docs.gitlab.com/ee/api/epics.html#list-epics-for-a-group) `GET /groups/:id/epics`
- [ ] [Single epic](https://docs.gitlab.com/ee/api/epics.html#single-epic) `GET /groups/:id/epics/:epic_iid`
- [ ] [New epic](https://docs.gitlab.com/ee/api/epics.html#new-epic) `POST /groups/:id/epics`
- [ ] [Update epic](https://docs.gitlab.com/ee/api/epics.html#update-epic) `PUT /groups/:id/epics/:epic_iid`
- [ ] [Delete epic](https://docs.gitlab.com/ee/api/epics.html#delete-epic) `DELETE /groups/:id/epics/:epic_iid`
- [ ] [Create a todo](https://docs.gitlab.com/ee/api/epics.html#create-a-todo) `POST /groups/:id/epics/:epic_iid/todo`

# [Events](https://docs.gitlab.com/ee/api/events.html)
- [ ] [List currently authenticated user’s events](https://docs.gitlab.com/ee/api/events.html#list-currently-authenticated-users-events) `GET /events`
- [ ] [Get user contribution events](https://docs.gitlab.com/ee/api/events.html#get-user-contribution-events) `GET /users/:id/events`
- [ ] [List a Project’s visible events](https://docs.gitlab.com/ee/api/events.html#list-a-projects-visible-events) `GET /projects/:project_id/events`

# [Features flags](https://docs.gitlab.com/ee/api/feature_flags.html)
- [ ] [List feature flags for a project](https://docs.gitlab.com/ee/api/feature_flags.html#list-feature-flags-for-a-project) `GET /projects/:id/feature_flags`
- [ ] [Get a single feature flag](https://docs.gitlab.com/ee/api/feature_flags.html#get-a-single-feature-flag) `GET /projects/:id/feature_flags/:feature_flag_name`
- [ ] [Create a feature flag](https://docs.gitlab.com/ee/api/feature_flags.html#create-a-feature-flag) `POST /projects/:id/feature_flags`
- [ ] [Update a feature flag](https://docs.gitlab.com/ee/api/feature_flags.html#update-a-feature-flag) `PUT /projects/:id/feature_flags/:feature_flag_name`
- [ ] [Delete a feature flag](https://docs.gitlab.com/ee/api/feature_flags.html#delete-a-feature-flag) `DELETE /projects/:id/feature_flags/:feature_flag_name`

# [Feature flag user lists](https://docs.gitlab.com/ee/api/feature_flag_user_lists.html)
- [ ] [List all feature flag user lists for a project](https://docs.gitlab.com/ee/api/feature_flag_user_lists.html#list-all-feature-flag-user-lists-for-a-project) `GET /projects/:id/feature_flags_user_lists`
- [ ] [Create a feature flag user list](https://docs.gitlab.com/ee/api/feature_flag_user_lists.html#create-a-feature-flag-user-list) `POST /projects/:id/feature_flags_user_lists`
- [ ] [Get a feature flag user list](https://docs.gitlab.com/ee/api/feature_flag_user_lists.html#get-a-feature-flag-user-list) `GET /projects/:id/feature_flags_user_lists/:iid`
- [ ] [Update a feature flag user list](https://docs.gitlab.com/ee/api/feature_flag_user_lists.html#update-a-feature-flag-user-list) `PUT /projects/:id/feature_flags_user_lists/:iid`
- [ ] [Delete feature flag user list](https://docs.gitlab.com/ee/api/feature_flag_user_lists.html#delete-feature-flag-user-list) `DELETE /projects/:id/feature_flags_user_lists/:iid`

# [Freeze periods](https://docs.gitlab.com/ee/api/freeze_periods.html)
- [ ] [List Freeze Periods](https://docs.gitlab.com/ee/api/freeze_periods.html#list-freeze-periods) `GET /projects/:id/freeze_periods`
- [ ] [Get a Freeze Period by a freeze_period_id](https://docs.gitlab.com/ee/api/freeze_periods.html#get-a-freeze-period-by-a-freeze_period_id) `GET /projects/:id/freeze_periods/:freeze_period_id`
- [ ] [Create a Freeze Period](https://docs.gitlab.com/ee/api/freeze_periods.html#create-a-freeze-period) `POST /projects/:id/freeze_periods`
- [ ] [Update a Freeze Period](https://docs.gitlab.com/ee/api/freeze_periods.html#update-a-freeze-period) `PUT /projects/:id/freeze_periods/:tag_name`
- [ ] [Delete a Freeze Period](https://docs.gitlab.com/ee/api/freeze_periods.html#delete-a-freeze-period) `DELETE /projects/:id/freeze_periods/:freeze_period_id`

# [Geo nodes](https://docs.gitlab.com/ee/api/geo_nodes.html)
- [ ] [Create a new Geo node](https://docs.gitlab.com/ee/api/geo_nodes.html#create-a-new-geo-node) `POST /geo_nodes`
- [ ] [Retrieve configuration about all Geo nodes](https://docs.gitlab.com/ee/api/geo_nodes.html#retrieve-configuration-about-all-geo-nodes) `GET /geo_nodes`
- [ ] [Retrieve configuration about a specific Geo node](https://docs.gitlab.com/ee/api/geo_nodes.html#retrieve-configuration-about-a-specific-geo-node) `GET /geo_nodes/:id`
- [ ] [Edit a Geo node](https://docs.gitlab.com/ee/api/geo_nodes.html#edit-a-geo-node) `PUT /geo_nodes/:id`
- [ ] [Delete a Geo node](https://docs.gitlab.com/ee/api/geo_nodes.html#delete-a-geo-node) `DELETE /geo_nodes/:id`
- [ ] [Repair a Geo node](https://docs.gitlab.com/ee/api/geo_nodes.html#repair-a-geo-node) `POST /geo_nodes/:id/repair`
- [ ] [Retrieve status about all Geo nodes](https://docs.gitlab.com/ee/api/geo_nodes.html#retrieve-status-about-all-geo-nodes) `GET /geo_nodes/status`
- [ ] [Retrieve status about a specific Geo node](https://docs.gitlab.com/ee/api/geo_nodes.html#retrieve-status-about-a-specific-geo-node) `GET /geo_nodes/:id/status`
- [ ] [Retrieve project sync or verification failures that occurred on the current node](https://docs.gitlab.com/ee/api/geo_nodes.html#retrieve-project-sync-or-verification-failures-that-occurred-on-the-current-node) `GET /geo_nodes/current/failures`

# [Group activity analytics](https://docs.gitlab.com/ee/api/group_activity_analytics.html)
- [ ] [Get count of recently created issues for group](https://docs.gitlab.com/ee/api/group_activity_analytics.html#get-count-of-recently-created-issues-for-group) `GET /analytics/group_activity/issues_count`
- [ ] [Get count of recently created merge requests for group](https://docs.gitlab.com/ee/api/group_activity_analytics.html#get-count-of-recently-created-merge-requests-for-group) `GET /analytics/group_activity/merge_requests_count`
- [ ] [Get count of members recently added to group](https://docs.gitlab.com/ee/api/group_activity_analytics.html#get-count-of-members-recently-added-to-group) `GET /analytics/group_activity/new_members_count`

# [Groups](https://docs.gitlab.com/ee/api/groups.html)
- [ ] [List groups](https://docs.gitlab.com/ee/api/groups.html#list-groups) `GET /groups`
- [ ] [List a group’s subgroups](https://docs.gitlab.com/ee/api/groups.html#list-a-groups-subgroups) `GET /groups/:id/subgroups`
- [ ] [List a group’s projects](https://docs.gitlab.com/ee/api/groups.html#list-a-groups-projects) `GET /groups/:id/projects`
- [ ] [List a group’s shared projects](https://docs.gitlab.com/ee/api/groups.html#list-a-groups-shared-projects) `GET /groups/:id/projects/shared`
- [ ] [Details of a group](https://docs.gitlab.com/ee/api/groups.html#details-of-a-group) `GET /groups/:id`
- [ ] [New group](https://docs.gitlab.com/ee/api/groups.html#new-group) `POST /groups`
- [ ] [Transfer project to group](https://docs.gitlab.com/ee/api/groups.html#transfer-project-to-group) `POST /groups/:id/projects/:project_id`
- [ ] [Update group](https://docs.gitlab.com/ee/api/groups.html#update-group) `PUT /groups/:id`
- [ ] [Remove group](https://docs.gitlab.com/ee/api/groups.html#remove-group) `DELETE /groups/:id`
- [ ] [Restore group marked for deletion](https://docs.gitlab.com/ee/api/groups.html#restore-group-marked-for-deletion-premium) `POST /groups/:id/restore`
- [ ] [List group hooks](https://docs.gitlab.com/ee/api/groups.html#list-group-hooks) `GET /groups/:id/hooks`
- [ ] [Get group hook](https://docs.gitlab.com/ee/api/groups.html#get-group-hook) `GET /groups/:id/hooks/:hook_id`
- [ ] [Add group hook](https://docs.gitlab.com/ee/api/groups.html#add-group-hook) `POST /groups/:id/hooks`
- [ ] [Edit group hook](https://docs.gitlab.com/ee/api/groups.html#edit-group-hook) `PUT /groups/:id/hooks/:hook_id`
- [ ] [Delete group hook](https://docs.gitlab.com/ee/api/groups.html#delete-group-hook) `DELETE /groups/:id/hooks/:hook_id`
- [ ] [Sync group with LDAP](https://docs.gitlab.com/ee/api/groups.html#sync-group-with-ldap-starter) `POST /groups/:id/ldap_sync`
- [ ] [List LDAP group links](https://docs.gitlab.com/ee/api/groups.html#list-ldap-group-links-starter) `GET /groups/:id/ldap_group_links`
- [ ] [Add LDAP group link with CN or filter](https://docs.gitlab.com/ee/api/groups.html#add-ldap-group-link-with-cn-or-filter-starter) `POST /groups/:id/ldap_group_links`
- [ ] [Delete LDAP group link](https://docs.gitlab.com/ee/api/groups.html#delete-ldap-group-link-starter) `DELETE /groups/:id/ldap_group_links/:cn`
- [ ] [Delete LDAP group link with CN or filter](https://docs.gitlab.com/ee/api/groups.html#delete-ldap-group-link-with-cn-or-filter-starter) `DELETE /groups/:id/ldap_group_links`
- [ ] [Create a link to share a group with another group](https://docs.gitlab.com/ee/api/groups.html#create-a-link-to-share-a-group-with-another-group) `POST /groups/:id/share`
- [ ] [Delete link sharing group with another group](https://docs.gitlab.com/ee/api/groups.html#delete-link-sharing-group-with-another-group) `DELETE /groups/:id/share/:group_id`
- [ ] [Get group push rules](https://docs.gitlab.com/ee/api/groups.html#get-group-push-rules) `GET /groups/:id/push_rule`

# [Import](https://docs.gitlab.com/ee/api/import.html)
- [ ] [Import repository from GitHub](https://docs.gitlab.com/ee/api/import.html#import-repository-from-github) `POST /import/github`
- [ ] [Import repository from Bitbucket Server](https://docs.gitlab.com/ee/api/import.html#import-repository-from-bitbucket-server) `POST /import/bitbucket_server`

# [Issue boards (project)](https://docs.gitlab.com/ee/api/boards.html)
- [ ] [Project Board](https://docs.gitlab.com/ee/api/boards.html#project-board) `GET /projects/:id/boards`
- [ ] [Single board](https://docs.gitlab.com/ee/api/boards.html#single-board) `GET /projects/:id/boards/:board_id`
- [ ] [Create a board](https://docs.gitlab.com/ee/api/boards.html#create-a-board-starter) `POST /projects/:id/boards`
- [ ] [Update a board](https://docs.gitlab.com/ee/api/boards.html#update-a-board-starter) `PUT /projects/:id/boards/:board_id`
- [ ] [Delete a board](https://docs.gitlab.com/ee/api/boards.html#delete-a-board-starter) `DELETE /projects/:id/boards/:board_id`
- [ ] [List board lists](https://docs.gitlab.com/ee/api/boards.html#list-board-lists) `GET /projects/:id/boards/:board_id/lists`
- [ ] [Single board list](https://docs.gitlab.com/ee/api/boards.html#single-board-list) `GET /projects/:id/boards/:board_id/lists/:list_id`
- [ ] [New board list](https://docs.gitlab.com/ee/api/boards.html#new-board-list) `POST /projects/:id/boards/:board_id/lists`
- [ ] [Edit board list](https://docs.gitlab.com/ee/api/boards.html#edit-board-list) `PUT /projects/:id/boards/:board_id/lists/:list_id`
- [ ] [Delete a board list](https://docs.gitlab.com/ee/api/boards.html#delete-a-board-list) `DELETE /projects/:id/boards/:board_id/lists/:list_id`

# [Issue boards (group)](https://docs.gitlab.com/ee/api/group_boards.html)
- [ ] [List all group issue boards in a group](https://docs.gitlab.com/ee/api/group_boards.html#list-all-group-issue-boards-in-a-group) `GET /groups/:id/boards`
- [ ] [Single group issue board](https://docs.gitlab.com/ee/api/group_boards.html#single-group-issue-board) `GET /groups/:id/boards/:board_id`
- [ ] [Create a group issue board](https://docs.gitlab.com/ee/api/group_boards.html#create-a-group-issue-board-premium) `POST /groups/:id/boards`
- [ ] [Update a group issue board](https://docs.gitlab.com/ee/api/group_boards.html#update-a-group-issue-board-premium) `PUT /groups/:id/boards/:board_id`
- [ ] [Delete a group issue board](https://docs.gitlab.com/ee/api/group_boards.html#delete-a-group-issue-board-premium) `DELETE /groups/:id/boards/:board_id`
- [ ] [List group issue board lists](https://docs.gitlab.com/ee/api/group_boards.html#list-group-issue-board-lists) `GET /groups/:id/boards/:board_id/lists`
- [ ] [Single group issue board list](https://docs.gitlab.com/ee/api/group_boards.html#single-group-issue-board-list) `GET /groups/:id/boards/:board_id/lists/:list_id`
- [ ] [New group issue board list](https://docs.gitlab.com/ee/api/group_boards.html#new-group-issue-board-list) `POST /groups/:id/boards/:board_id/lists`
- [ ] [Edit group issue board list](https://docs.gitlab.com/ee/api/group_boards.html#edit-group-issue-board-list) `PUT /groups/:id/boards/:board_id/lists/:list_id`
- [ ] [Delete a group issue board list](https://docs.gitlab.com/ee/api/group_boards.html#delete-a-group-issue-board-list) `DELETE /groups/:id/boards/:board_id/lists/:list_id`

# [Issues](https://docs.gitlab.com/ee/api/issues.html)
- [ ] [List issues](https://docs.gitlab.com/ee/api/issues.html#list-issues) `GET /issues`
- [ ] [List group issues](https://docs.gitlab.com/ee/api/issues.html#list-group-issues) `GET /groups/:id/issues`
- [ ] [List project issues](https://docs.gitlab.com/ee/api/issues.html#list-project-issues) `GET /projects/:id/issues`
- [ ] [Single issue](https://docs.gitlab.com/ee/api/issues.html#single-issue) `GET /projects/:id/issues/:issue_iid`
- [x] [New issue](https://docs.gitlab.com/ee/api/issues.html#new-issue) `POST /projects/:id/issues`
- [ ] [Edit issue](https://docs.gitlab.com/ee/api/issues.html#edit-issue) `PUT /projects/:id/issues/:issue_iid`
- [ ] [Delete an issue](https://docs.gitlab.com/ee/api/issues.html#delete-an-issue) `DELETE /projects/:id/issues/:issue_iid`
- [ ] [Reorder an issue](https://docs.gitlab.com/ee/api/issues.html#reorder-an-issue) `PUT /projects/:id/issues/:issue_iid/reorder`
- [ ] [Move an issue](https://docs.gitlab.com/ee/api/issues.html#move-an-issue) `POST /projects/:id/issues/:issue_iid/move`
- [ ] [Subscribe to an issue](https://docs.gitlab.com/ee/api/issues.html#subscribe-to-an-issue) `POST /projects/:id/issues/:issue_iid/subscribe`
- [ ] [Unsubscribe from an issue](https://docs.gitlab.com/ee/api/issues.html#unsubscribe-from-an-issue) `POST /projects/:id/issues/:issue_iid/unsubscribe`
- [ ] [Create a todo](https://docs.gitlab.com/ee/api/issues.html#create-a-todo) `POST /projects/:id/issues/:issue_iid/todo`
- [ ] [Set a time estimate for an issue](https://docs.gitlab.com/ee/api/issues.html#set-a-time-estimate-for-an-issue) `POST /projects/:id/issues/:issue_iid/time_estimate`
- [ ] [Reset the time estimate for an issue](https://docs.gitlab.com/ee/api/issues.html#reset-the-time-estimate-for-an-issue) `POST /projects/:id/issues/:issue_iid/reset_time_estimate`
- [ ] [Add spent time for an issue](https://docs.gitlab.com/ee/api/issues.html#add-spent-time-for-an-issue) `POST /projects/:id/issues/:issue_iid/add_spent_time`
- [ ] [Reset spent time for an issue](https://docs.gitlab.com/ee/api/issues.html#reset-spent-time-for-an-issue) `POST /projects/:id/issues/:issue_iid/reset_spent_time`
- [ ] [Get time tracking stats](https://docs.gitlab.com/ee/api/issues.html#get-time-tracking-stats) `GET /projects/:id/issues/:issue_iid/time_stats`
- [ ] [List merge requests related to issue](https://docs.gitlab.com/ee/api/issues.html#list-merge-requests-related-to-issue) `GET /projects/:id/issues/:issue_id/related_merge_requests`
- [ ] [List merge requests that will close issue on merge](https://docs.gitlab.com/ee/api/issues.html#list-merge-requests-that-will-close-issue-on-merge) `GET /projects/:id/issues/:issue_iid/closed_by`
- [ ] [Participants on issues](https://docs.gitlab.com/ee/api/issues.html#participants-on-issues) `GET /projects/:id/issues/:issue_iid/participants`
- [ ] [Get user agent details](https://docs.gitlab.com/ee/api/issues.html#get-user-agent-details) `GET /projects/:id/issues/:issue_iid/user_agent_detail`

# [Issues (epic)](https://docs.gitlab.com/ee/api/epic_issues.html)
- [ ] [List issues for an epic](https://docs.gitlab.com/ee/api/epic_issues.html#list-issues-for-an-epic) `GET /groups/:id/epics/:epic_iid/issues`
- [ ] [Assign an issue to the epic](https://docs.gitlab.com/ee/api/epic_issues.html#assign-an-issue-to-the-epic) `POST /groups/:id/epics/:epic_iid/issues/:issue_id`
- [ ] [Remove an issue from the epic](https://docs.gitlab.com/ee/api/epic_issues.html#remove-an-issue-from-the-epic) `DELETE /groups/:id/epics/:epic_iid/issues/:epic_issue_id`
- [ ] [Update epic - issue association](https://docs.gitlab.com/ee/api/epic_issues.html#update-epic---issue-association) `PUT /groups/:id/epics/:epic_iid/issues/:epic_issue_id`

# [Issues statistics](https://docs.gitlab.com/ee/api/issues_statistics.html)
- [ ] [Get issues statistics](https://docs.gitlab.com/ee/api/issues_statistics.html#get-issues-statistics) `GET /issues_statistics`
- [ ] [Get group issues statistics](https://docs.gitlab.com/ee/api/issues_statistics.html#get-group-issues-statistics) `GET /groups/:id/issues_statistics`
- [ ] [Get project issues statistics](https://docs.gitlab.com/ee/api/issues_statistics.html#get-project-issues-statistics) `GET /projects/:id/issues_statistics`

# [Jobs](https://docs.gitlab.com/ee/api/jobs.html)
- [ ] [List project jobs](https://docs.gitlab.com/ee/api/jobs.html#list-project-jobs) `GET /projects/:id/jobs`
- [ ] [List pipeline jobs](https://docs.gitlab.com/ee/api/jobs.html#list-pipeline-jobs) `GET /projects/:id/pipelines/:pipeline_id/jobs`
- [ ] [List pipeline bridges](https://docs.gitlab.com/ee/api/jobs.html#list-pipeline-bridges) `GET /projects/:id/pipelines/:pipeline_id/bridges`
- [ ] [Get a single job](https://docs.gitlab.com/ee/api/jobs.html#get-a-single-job) `GET /projects/:id/jobs/:job_id`
- [ ] [Get a log file](https://docs.gitlab.com/ee/api/jobs.html#get-a-log-file) `GET /projects/:id/jobs/:job_id/trace`
- [ ] [Cancel a job](https://docs.gitlab.com/ee/api/jobs.html#cancel-a-job) `POST /projects/:id/jobs/:job_id/cancel`
- [ ] [Retry a job](https://docs.gitlab.com/ee/api/jobs.html#retry-a-job) `POST /projects/:id/jobs/:job_id/retry`
- [ ] [Erase a job](https://docs.gitlab.com/ee/api/jobs.html#erase-a-job) `POST /projects/:id/jobs/:job_id/erase`
- [ ] [Play a job](https://docs.gitlab.com/ee/api/jobs.html#play-a-job) `POST /projects/:id/jobs/:job_id/play`

# [Job artifacts](https://docs.gitlab.com/ee/api/job_artifacts.html)
- [ ] [Get job artifacts](https://docs.gitlab.com/ee/api/job_artifacts.html#get-job-artifacts) `GET /projects/:id/jobs/:job_id/artifacts`
- [ ] [Download the artifacts archive](https://docs.gitlab.com/ee/api/job_artifacts.html#download-the-artifacts-archive) `GET /projects/:id/jobs/artifacts/:ref_name/download`
- [ ] [Download a single artifact file by job ID](https://docs.gitlab.com/ee/api/job_artifacts.html#download-a-single-artifact-file-by-job-id) `GET /projects/:id/jobs/:job_id/artifacts/*artifact_path`
- [ ] [Download a single artifact file from specific tag or branch](https://docs.gitlab.com/ee/api/job_artifacts.html#download-a-single-artifact-file-from-specific-tag-or-branch) `GET /projects/:id/jobs/artifacts/:ref_name/raw/*artifact_path`
- [ ] [Keep artifacts](https://docs.gitlab.com/ee/api/job_artifacts.html#keep-artifacts) `POST /projects/:id/jobs/:job_id/artifacts/keep`
- [ ] [Delete artifacts](https://docs.gitlab.com/ee/api/job_artifacts.html#delete-artifacts) `DELETE /projects/:id/jobs/:job_id/artifacts`

# [Keys](https://docs.gitlab.com/ee/api/keys.html)
- [ ] [Get SSH key with user by ID of an SSH key](https://docs.gitlab.com/ee/api/keys.html#get-ssh-key-with-user-by-id-of-an-ssh-key) `GET /keys/:id`
- [ ] [Get user by fingerprint of SSH key](https://docs.gitlab.com/ee/api/keys.html#get-user-by-fingerprint-of-ssh-key) `GET /keys`

# [Labels (project)](https://docs.gitlab.com/ee/api/labels.html)
- [ ] [List labels](https://docs.gitlab.com/ee/api/labels.html#list-labels) `GET /projects/:id/labels`
- [ ] [Get a single project label](https://docs.gitlab.com/ee/api/labels.html#get-a-single-project-label) `GET /projects/:id/labels/:label_id`
- [ ] [Create a new label](https://docs.gitlab.com/ee/api/labels.html#create-a-new-label) `POST /projects/:id/labels`
- [ ] [Delete a label](https://docs.gitlab.com/ee/api/labels.html#delete-a-label) `DELETE /projects/:id/labels/:label_id`
- [ ] [Edit an existing label](https://docs.gitlab.com/ee/api/labels.html#edit-an-existing-label) `PUT /projects/:id/labels/:label_id`
- [ ] [Promote a project label to a group label](https://docs.gitlab.com/ee/api/labels.html#promote-a-project-label-to-a-group-label) `PUT /projects/:id/labels/:label_id/promote`
- [ ] [Subscribe to a label](https://docs.gitlab.com/ee/api/labels.html#subscribe-to-a-label) `POST /projects/:id/labels/:label_id/subscribe`
- [ ] [Unsubscribe from a label](https://docs.gitlab.com/ee/api/labels.html#unsubscribe-from-a-label) `POST /projects/:id/labels/:label_id/unsubscribe`

# [Labels (group)](https://docs.gitlab.com/ee/api/group_labels.html)
- [ ] [List group labels](https://docs.gitlab.com/ee/api/group_labels.html#list-group-labels) `GET /groups/:id/labels`
- [ ] [Get a single group label](https://docs.gitlab.com/ee/api/group_labels.html#get-a-single-group-label) `GET /groups/:id/labels/:label_id`
- [ ] [Create a new group label](https://docs.gitlab.com/ee/api/group_labels.html#create-a-new-group-label) `POST /groups/:id/labels`
- [ ] [Update a group label](https://docs.gitlab.com/ee/api/group_labels.html#update-a-group-label) `PUT /groups/:id/labels/:label_id`
- [ ] [Delete a group label](https://docs.gitlab.com/ee/api/group_labels.html#delete-a-group-label) `DELETE /groups/:id/labels/:label_id`
- [ ] [Subscribe to a group label](https://docs.gitlab.com/ee/api/group_labels.html#subscribe-to-a-group-label) `POST /groups/:id/labels/:label_id/subscribe`
- [ ] [Unsubscribe from a group label](https://docs.gitlab.com/ee/api/group_labels.html#unsubscribe-from-a-group-label) `POST /groups/:id/labels/:label_id/unsubscribe`

# [License](https://docs.gitlab.com/ee/api/license.html)
- [ ] [Retrieve information about the current license](https://docs.gitlab.com/ee/api/license.html#retrieve-information-about-the-current-license) `GET /license`
- [ ] [Retrieve information about all licenses](https://docs.gitlab.com/ee/api/license.html#retrieve-information-about-all-licenses) `GET /licenses`
- [ ] [Add a new license](https://docs.gitlab.com/ee/api/license.html#add-a-new-license) `POST /license`
- [ ] [Delete a license](https://docs.gitlab.com/ee/api/license.html#delete-a-license) `DELETE /license/:id`

# [Licenses (templates)](https://docs.gitlab.com/ee/api/templates/licenses.html)
- [ ] [List license templates](https://docs.gitlab.com/ee/api/templates/licenses.html#list-license-templates) `GET /templates/licenses`
- [ ] [Single license template](https://docs.gitlab.com/ee/api/templates/licenses.html#single-license-template) `GET /templates/licenses/:key`

# [Links (issue)](https://docs.gitlab.com/ee/api/issue_links.html)
- [ ] [List issue relations](https://docs.gitlab.com/ee/api/issue_links.html#list-issue-relations) `GET /projects/:id/issues/:issue_iid/links`
- [ ] [Create an issue link](https://docs.gitlab.com/ee/api/issue_links.html#create-an-issue-link) `POST /projects/:id/issues/:issue_iid/links`
- [ ] [Delete an issue link](https://docs.gitlab.com/ee/api/issue_links.html#delete-an-issue-link) `DELETE /projects/:id/issues/:issue_iid/links/:issue_link_id`

# [Links (epic)](https://docs.gitlab.com/ee/api/epic_links.html)
- [ ] [List epics related to a given epic](https://docs.gitlab.com/ee/api/epic_links.html#list-epics-related-to-a-given-epic) `GET /groups/:id/epics/:epic_iid/epics`
- [ ] [Assign a child epic](https://docs.gitlab.com/ee/api/epic_links.html#assign-a-child-epic) `POST /groups/:id/epics/:epic_iid/epics`
- [ ] [Re-order a child epic](https://docs.gitlab.com/ee/api/epic_links.html#re-order-a-child-epic) `PUT /groups/:id/epics/:epic_iid/epics/:child_epic_id`
- [ ] [Unassign a child epic](https://docs.gitlab.com/ee/api/epic_links.html#unassign-a-child-epic) `DELETE /groups/:id/epics/:epic_iid/epics/:child_epic_id`

# [Managed licenses](https://docs.gitlab.com/ee/api/managed_licenses.html)
- [ ] [List managed licenses](https://docs.gitlab.com/ee/api/managed_licenses.html#list-managed-licenses) `GET /projects/:id/managed_licenses`
- [ ] [Show an existing managed license](https://docs.gitlab.com/ee/api/managed_licenses.html#show-an-existing-managed-license) `GET /projects/:id/managed_licenses/:managed_license_id`
- [ ] [Create a new managed license](https://docs.gitlab.com/ee/api/managed_licenses.html#create-a-new-managed-license) `POST /projects/:id/managed_licenses`
- [ ] [Delete a managed license](https://docs.gitlab.com/ee/api/managed_licenses.html#delete-a-managed-license) `DELETE /projects/:id/managed_licenses/:managed_license_id`
- [ ] [Edit an existing managed license](https://docs.gitlab.com/ee/api/managed_licenses.html#edit-an-existing-managed-license) `PATCH /projects/:id/managed_licenses/:managed_license_id`

# [Markdown](https://docs.gitlab.com/ee/api/markdown.html)
- [ ] [Render an arbitrary Markdown document](https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document) `POST /api/v4/markdown`

# [Members](https://docs.gitlab.com/ee/api/members.html)
- [ ] [List all members of a group or project](https://docs.gitlab.com/ee/api/members.html#list-all-members-of-a-group-or-project) `GET /groups/:id/members`
- [ ] [List all members of a group or project](https://docs.gitlab.com/ee/api/members.html#list-all-members-of-a-group-or-project) `GET /projects/:id/members`
- [ ] [List all members of a group or project including inherited members](https://docs.gitlab.com/ee/api/members.html#list-all-members-of-a-group-or-project-including-inherited-members) `GET /groups/:id/members/all`
- [ ] [List all members of a group or project including inherited members](https://docs.gitlab.com/ee/api/members.html#list-all-members-of-a-group-or-project-including-inherited-members) `GET /projects/:id/members/all`
- [ ] [Get a member of a group or project](https://docs.gitlab.com/ee/api/members.html#get-a-member-of-a-group-or-project) `GET /groups/:id/members/:user_id`
- [ ] [Get a member of a group or project](https://docs.gitlab.com/ee/api/members.html#get-a-member-of-a-group-or-project) `GET /projects/:id/members/:user_id`
- [ ] [Get a member of a group or project, including inherited members](https://docs.gitlab.com/ee/api/members.html#get-a-member-of-a-group-or-project-including-inherited-members) `GET /groups/:id/members/all/:user_id`
- [ ] [Get a member of a group or project, including inherited members](https://docs.gitlab.com/ee/api/members.html#get-a-member-of-a-group-or-project-including-inherited-members) `GET /projects/:id/members/all/:user_id`
- [ ] [Add a member to a group or project](https://docs.gitlab.com/ee/api/members.html#add-a-member-to-a-group-or-project) `POST /groups/:id/members`
- [ ] [Add a member to a group or project](https://docs.gitlab.com/ee/api/members.html#add-a-member-to-a-group-or-project) `POST /projects/:id/members`
- [ ] [Edit a member of a group or project](https://docs.gitlab.com/ee/api/members.html#edit-a-member-of-a-group-or-project) `PUT /groups/:id/members/:user_id`
- [ ] [Edit a member of a group or project](https://docs.gitlab.com/ee/api/members.html#edit-a-member-of-a-group-or-project) `PUT /projects/:id/members/:user_id`
- [ ] [Set override flag for a member of a group](https://docs.gitlab.com/ee/api/members.html#set-override-flag-for-a-member-of-a-group) `POST /groups/:id/members/:user_id/override`
- [ ] [Remove override for a member of a group](https://docs.gitlab.com/ee/api/members.html#remove-override-for-a-member-of-a-group) `DELETE /groups/:id/members/:user_id/override`
- [ ] [Remove a member from a group or project](https://docs.gitlab.com/ee/api/members.html#remove-a-member-from-a-group-or-project) `DELETE /groups/:id/members/:user_id`
- [ ] [Remove a member from a group or project](https://docs.gitlab.com/ee/api/members.html#remove-a-member-from-a-group-or-project) `DELETE /projects/:id/members/:user_id`

# [Merge request approvals](https://docs.gitlab.com/ee/api/merge_request_approvals.html)
- [ ] [Get Configuration](https://docs.gitlab.com/ee/api/merge_request_approvals.html#get-configuration) `GET /projects/:id/approvals`
- [ ] [Change configuration](https://docs.gitlab.com/ee/api/merge_request_approvals.html#change-configuration) `POST /projects/:id/approvals`
- [ ] [Get project-level rules](https://docs.gitlab.com/ee/api/merge_request_approvals.html#get-project-level-rules) `GET /projects/:id/approval_rules`
- [ ] [Create project-level rule](https://docs.gitlab.com/ee/api/merge_request_approvals.html#create-project-level-rule) `POST /projects/:id/approval_rules`
- [ ] [Update project-level rule](https://docs.gitlab.com/ee/api/merge_request_approvals.html#update-project-level-rule) `PUT /projects/:id/approval_rules/:approval_rule_id`
- [ ] [Delete project-level rule](https://docs.gitlab.com/ee/api/merge_request_approvals.html#delete-project-level-rule) `DELETE /projects/:id/approval_rules/:approval_rule_id`
- [ ] [Change allowed approvers](https://docs.gitlab.com/ee/api/merge_request_approvals.html#change-allowed-approvers) `PUT /projects/:id/approvers`
- [ ] [Get Configuration](https://docs.gitlab.com/ee/api/merge_request_approvals.html#get-configuration-1) `GET /projects/:id/merge_requests/:merge_request_iid/approvals`
- [ ] [Change approval configuration](https://docs.gitlab.com/ee/api/merge_request_approvals.html#change-approval-configuration) `POST /projects/:id/merge_requests/:merge_request_iid/approvals`
- [ ] [Change allowed approvers for Merge Request](https://docs.gitlab.com/ee/api/merge_request_approvals.html#change-allowed-approvers-for-merge-request) `PUT /projects/:id/merge_requests/:merge_request_iid/approvers`
- [ ] [Get the approval state of merge requests](https://docs.gitlab.com/ee/api/merge_request_approvals.html#get-the-approval-state-of-merge-requests) `GET /projects/:id/merge_requests/:merge_request_iid/approval_state`
- [ ] [Get merge request level rules](https://docs.gitlab.com/ee/api/merge_request_approvals.html#get-merge-request-level-rules) `GET /projects/:id/merge_requests/:merge_request_iid/approval_rules`
- [ ] [Create merge request level rule](https://docs.gitlab.com/ee/api/merge_request_approvals.html#create-merge-request-level-rule) `POST /projects/:id/merge_requests/:merge_request_iid/approval_rules`
- [ ] [Update merge request level rule](https://docs.gitlab.com/ee/api/merge_request_approvals.html#update-merge-request-level-rule) `PUT /projects/:id/merge_requests/:merge_request_iid/approval_rules/:approval_rule_id`
- [ ] [Delete merge request level rule](https://docs.gitlab.com/ee/api/merge_request_approvals.html#delete-merge-request-level-rule) `DELETE /projects/:id/merge_requests/:merge_request_iid/approval_rules/:approval_rule_id`
- [ ] [Approve Merge Request](https://docs.gitlab.com/ee/api/merge_request_approvals.html#approve-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/approve`
- [ ] [Unapprove Merge Request](https://docs.gitlab.com/ee/api/merge_request_approvals.html#unapprove-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/unapprove`

# [Merge requests](https://docs.gitlab.com/ee/api/merge_requests.html)
- [x] [List merge requests](https://docs.gitlab.com/ee/api/merge_requests.html#list-merge-requests) `GET /merge_requests`
- [x] [List project merge requests](https://docs.gitlab.com/ee/api/merge_requests.html#list-project-merge-requests) `GET /projects/:id/merge_requests`
- [x] [List group merge requests](https://docs.gitlab.com/ee/api/merge_requests.html#list-group-merge-requests) `GET /groups/:id/merge_requests`
- [x] [Get single MR](https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr) `GET /projects/:id/merge_requests/:merge_request_iid`
- [ ] [Get single MR participants](https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr-participants) `GET /projects/:id/merge_requests/:merge_request_iid/participants`
- [ ] [Get single MR commits](https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr-commits) `GET /projects/:id/merge_requests/:merge_request_iid/commits`
- [ ] [Get single MR changes](https://docs.gitlab.com/ee/api/merge_requests.html#get-single-mr-changes) `GET /projects/:id/merge_requests/:merge_request_iid/changes`
- [ ] [List MR pipelines](https://docs.gitlab.com/ee/api/merge_requests.html#list-mr-pipelines) `GET /projects/:id/merge_requests/:merge_request_iid/pipelines`
- [ ] [Create MR Pipeline](https://docs.gitlab.com/ee/api/merge_requests.html#create-mr-pipeline) `POST /projects/:id/merge_requests/:merge_request_iid/pipelines`
- [x] [Create MR](https://docs.gitlab.com/ee/api/merge_requests.html#create-mr) `POST /projects/:id/merge_requests`
- [ ] [Update MR](https://docs.gitlab.com/ee/api/merge_requests.html#update-mr) `PUT /projects/:id/merge_requests/:merge_request_iid`
- [ ] [Delete a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#delete-a-merge-request) `DELETE /projects/:id/merge_requests/:merge_request_iid`
- [ ] [Accept MR](https://docs.gitlab.com/ee/api/merge_requests.html#accept-mr) `PUT /projects/:id/merge_requests/:merge_request_iid/merge`
- [ ] [Merge to default merge ref path](https://docs.gitlab.com/ee/api/merge_requests.html#merge-to-default-merge-ref-path) `GET /projects/:id/merge_requests/:merge_request_iid/merge_ref`
- [ ] [Cancel Merge When Pipeline Succeeds](https://docs.gitlab.com/ee/api/merge_requests.html#cancel-merge-when-pipeline-succeeds) `POST /projects/:id/merge_requests/:merge_request_iid/cancel_merge_when_pipeline_succeeds`
- [ ] [Rebase a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#rebase-a-merge-request) `PUT /projects/:id/merge_requests/:merge_request_iid/rebase`
- [ ] [List issues that will close on merge](https://docs.gitlab.com/ee/api/merge_requests.html#list-issues-that-will-close-on-merge) `GET /projects/:id/merge_requests/:merge_request_iid/closes_issues`
- [ ] [Subscribe to a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#subscribe-to-a-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/subscribe`
- [ ] [Unsubscribe from a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#unsubscribe-from-a-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/unsubscribe`
- [ ] [Create a todo](https://docs.gitlab.com/ee/api/merge_requests.html#create-a-todo) `POST /projects/:id/merge_requests/:merge_request_iid/todo`
- [ ] [Get MR diff versions](https://docs.gitlab.com/ee/api/merge_requests.html#get-mr-diff-versions) `GET /projects/:id/merge_requests/:merge_request_iid/versions`
- [ ] [Get a single MR diff version](https://docs.gitlab.com/ee/api/merge_requests.html#get-a-single-mr-diff-version) `GET /projects/:id/merge_requests/:merge_request_iid/versions/:version_id`
- [ ] [Set a time estimate for a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#set-a-time-estimate-for-a-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/time_estimate`
- [ ] [Reset the time estimate for a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#reset-the-time-estimate-for-a-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/reset_time_estimate`
- [ ] [Add spent time for a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#add-spent-time-for-a-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/add_spent_time`
- [ ] [Reset spent time for a merge request](https://docs.gitlab.com/ee/api/merge_requests.html#reset-spent-time-for-a-merge-request) `POST /projects/:id/merge_requests/:merge_request_iid/reset_spent_time`
- [ ] [Get time tracking stats](https://docs.gitlab.com/ee/api/merge_requests.html#get-time-tracking-stats) `GET /projects/:id/merge_requests/:merge_request_iid/time_stats`

# [Milestones (project)](https://docs.gitlab.com/ee/api/milestones.html)
- [ ] [List project milestones](https://docs.gitlab.com/ee/api/milestones.html#list-project-milestones) `GET /projects/:id/milestones`
- [ ] [Get single milestone](https://docs.gitlab.com/ee/api/milestones.html#get-single-milestone) `GET /projects/:id/milestones/:milestone_id`
- [ ] [Create new milestone](https://docs.gitlab.com/ee/api/milestones.html#create-new-milestone) `POST /projects/:id/milestones`
- [ ] [Edit milestone](https://docs.gitlab.com/ee/api/milestones.html#edit-milestone) `PUT /projects/:id/milestones/:milestone_id`
- [ ] [Delete project milestone](https://docs.gitlab.com/ee/api/milestones.html#delete-project-milestone) `DELETE /projects/:id/milestones/:milestone_id`
- [ ] [Get all issues assigned to a single milestone](https://docs.gitlab.com/ee/api/milestones.html#get-all-issues-assigned-to-a-single-milestone) `GET /projects/:id/milestones/:milestone_id/issues`
- [ ] [Get all merge requests assigned to a single milestone](https://docs.gitlab.com/ee/api/milestones.html#get-all-merge-requests-assigned-to-a-single-milestone) `GET /projects/:id/milestones/:milestone_id/merge_requests`
- [ ] [Promote project milestone to a group milestone](https://docs.gitlab.com/ee/api/milestones.html#promote-project-milestone-to-a-group-milestone) `POST /projects/:id/milestones/:milestone_id/promote`
- [ ] [Get all burndown chart events for a single milestone](https://docs.gitlab.com/ee/api/milestones.html#get-all-burndown-chart-events-for-a-single-milestone-starter) `GET /projects/:id/milestones/:milestone_id/burndown_events`

# [Milestones (group)](https://docs.gitlab.com/ee/api/group_milestones.html)
- [ ] [List group milestones](https://docs.gitlab.com/ee/api/group_milestones.html#list-group-milestones) `GET /groups/:id/milestones`
- [ ] [Get single milestone](https://docs.gitlab.com/ee/api/group_milestones.html#get-single-milestone) `GET /groups/:id/milestones/:milestone_id`
- [ ] [Create new milestone](https://docs.gitlab.com/ee/api/group_milestones.html#create-new-milestone) `POST /groups/:id/milestones`
- [ ] [Edit milestone](https://docs.gitlab.com/ee/api/group_milestones.html#edit-milestone) `PUT /groups/:id/milestones/:milestone_id`
- [ ] [Delete group milestone](https://docs.gitlab.com/ee/api/group_milestones.html#delete-group-milestone) `DELETE /groups/:id/milestones/:milestone_id`
- [ ] [Get all issues assigned to a single milestone](https://docs.gitlab.com/ee/api/group_milestones.html#get-all-issues-assigned-to-a-single-milestone) `GET /groups/:id/milestones/:milestone_id/issues`
- [ ] [Get all merge requests assigned to a single milestone](https://docs.gitlab.com/ee/api/group_milestones.html#get-all-merge-requests-assigned-to-a-single-milestone) `GET /groups/:id/milestones/:milestone_id/merge_requests`
- [ ] [Get all burndown chart events for a single milestone](https://docs.gitlab.com/ee/api/group_milestones.html#get-all-burndown-chart-events-for-a-single-milestone-starter) `GET /groups/:id/milestones/:milestone_id/burndown_events`

# [Namespaces](https://docs.gitlab.com/ee/api/namespaces.html)
- [ ] [List namespaces](https://docs.gitlab.com/ee/api/namespaces.html#list-namespaces) `GET /namespaces`
- [ ] [Get namespace by ID](https://docs.gitlab.com/ee/api/namespaces.html#get-namespace-by-id) `GET /namespaces/:id`

# [Notes (comments)](https://docs.gitlab.com/ee/api/notes.html)
- [ ] [List project issue notes](https://docs.gitlab.com/ee/api/notes.html#list-project-issue-notes) `GET /projects/:id/issues/:issue_iid/notes`
- [ ] [Get single issue note](https://docs.gitlab.com/ee/api/notes.html#get-single-issue-note) `GET /projects/:id/issues/:issue_iid/notes/:note_id`
- [ ] [Create new issue note](https://docs.gitlab.com/ee/api/notes.html#create-new-issue-note) `POST /projects/:id/issues/:issue_iid/notes`
- [ ] [Modify existing issue note](https://docs.gitlab.com/ee/api/notes.html#modify-existing-issue-note) `PUT /projects/:id/issues/:issue_iid/notes/:note_id`
- [ ] [Delete an issue note](https://docs.gitlab.com/ee/api/notes.html#delete-an-issue-note) `DELETE /projects/:id/issues/:issue_iid/notes/:note_id`
- [ ] [List all snippet notes](https://docs.gitlab.com/ee/api/notes.html#list-all-snippet-notes) `GET /projects/:id/snippets/:snippet_id/notes`
- [ ] [Get single snippet note](https://docs.gitlab.com/ee/api/notes.html#get-single-snippet-note) `GET /projects/:id/snippets/:snippet_id/notes/:note_id`
- [ ] [Create new snippet note](https://docs.gitlab.com/ee/api/notes.html#create-new-snippet-note) `POST /projects/:id/snippets/:snippet_id/notes`
- [ ] [Modify existing snippet note](https://docs.gitlab.com/ee/api/notes.html#modify-existing-snippet-note) `PUT /projects/:id/snippets/:snippet_id/notes/:note_id`
- [ ] [Delete a snippet note](https://docs.gitlab.com/ee/api/notes.html#delete-a-snippet-note) `DELETE /projects/:id/snippets/:snippet_id/notes/:note_id`
- [ ] [List all merge request notes](https://docs.gitlab.com/ee/api/notes.html#list-all-merge-request-notes) `GET /projects/:id/merge_requests/:merge_request_iid/notes`
- [ ] [Get single merge request note](https://docs.gitlab.com/ee/api/notes.html#get-single-merge-request-note) `GET /projects/:id/merge_requests/:merge_request_iid/notes/:note_id`
- [ ] [Create new merge request note](https://docs.gitlab.com/ee/api/notes.html#create-new-merge-request-note) `POST /projects/:id/merge_requests/:merge_request_iid/notes`
- [ ] [Modify existing merge request note](https://docs.gitlab.com/ee/api/notes.html#modify-existing-merge-request-note) `PUT /projects/:id/merge_requests/:merge_request_iid/notes/:note_id`
- [ ] [Delete a merge request note](https://docs.gitlab.com/ee/api/notes.html#delete-a-merge-request-note) `DELETE /projects/:id/merge_requests/:merge_request_iid/notes/:note_id`
- [ ] [List all epic notes](https://docs.gitlab.com/ee/api/notes.html#list-all-epic-notes) `GET /groups/:id/epics/:epic_id/notes`
- [ ] [Get single epic note](https://docs.gitlab.com/ee/api/notes.html#get-single-epic-note) `GET /groups/:id/epics/:epic_id/notes/:note_id`
- [ ] [Create new epic note](https://docs.gitlab.com/ee/api/notes.html#create-new-epic-note) `POST /groups/:id/epics/:epic_id/notes`
- [ ] [Modify existing epic note](https://docs.gitlab.com/ee/api/notes.html#modify-existing-epic-note) `PUT /groups/:id/epics/:epic_id/notes/:note_id`
- [ ] [Delete an epic note](https://docs.gitlab.com/ee/api/notes.html#delete-an-epic-note) `DELETE /groups/:id/epics/:epic_id/notes/:note_id`

# [Notification settings](https://docs.gitlab.com/ee/api/notification_settings.html)
- [ ] [Global notification settings](https://docs.gitlab.com/ee/api/notification_settings.html#global-notification-settings) `GET /notification_settings`
- [ ] [Update global notification settings](https://docs.gitlab.com/ee/api/notification_settings.html#update-global-notification-settings) `PUT /notification_settings`
- [ ] [Group / project level notification settings](https://docs.gitlab.com/ee/api/notification_settings.html#group--project-level-notification-settings) `GET /groups/:id/notification_settings`
- [ ] [Group / project level notification settings](https://docs.gitlab.com/ee/api/notification_settings.html#group--project-level-notification-settings) `GET /projects/:id/notification_settings`
- [ ] [Update group/project level notification settings](https://docs.gitlab.com/ee/api/notification_settings.html#update-groupproject-level-notification-settings) `PUT /groups/:id/notification_settings`
- [ ] [Update group/project level notification settings](https://docs.gitlab.com/ee/api/notification_settings.html#update-groupproject-level-notification-settings) `PUT /projects/:id/notification_settings`

# [Packages](https://docs.gitlab.com/ee/api/packages.html)
- [ ] [Within a project](https://docs.gitlab.com/ee/api/packages.html#within-a-project) `GET /projects/:id/packages`
- [ ] [Within a group](https://docs.gitlab.com/ee/api/packages.html#within-a-group) `GET /groups/:id/packages`
- [ ] [Get a project package](https://docs.gitlab.com/ee/api/packages.html#get-a-project-package) `GET /projects/:id/packages/:package_id`
- [ ] [List package files](https://docs.gitlab.com/ee/api/packages.html#list-package-files) `GET /projects/:id/packages/:package_id/package_files`
- [ ] [Delete a project package](https://docs.gitlab.com/ee/api/packages.html#delete-a-project-package) `DELETE /projects/:id/packages/:package_id`

# [Pages domains](https://docs.gitlab.com/ee/api/pages_domains.html)
- [ ] [List all pages domains](https://docs.gitlab.com/ee/api/pages_domains.html#list-all-pages-domains) `GET /pages/domains`
- [ ] [List pages domains](https://docs.gitlab.com/ee/api/pages_domains.html#list-pages-domains) `GET /projects/:id/pages/domains`
- [ ] [Single pages domain](https://docs.gitlab.com/ee/api/pages_domains.html#single-pages-domain) `GET /projects/:id/pages/domains/:domain`
- [ ] [Create new pages domain](https://docs.gitlab.com/ee/api/pages_domains.html#create-new-pages-domain) `POST /projects/:id/pages/domains`
- [ ] [Update pages domain](https://docs.gitlab.com/ee/api/pages_domains.html#update-pages-domain) `PUT /projects/:id/pages/domains/:domain`
- [ ] [Delete pages domain](https://docs.gitlab.com/ee/api/pages_domains.html#delete-pages-domain) `DELETE /projects/:id/pages/domains/:domain`

# [Personal access tokens](https://docs.gitlab.com/ee/api/personal_access_tokens.html)
- [ ] [List personal access tokens](https://docs.gitlab.com/ee/api/personal_access_tokens.html#list-personal-access-tokens) `GET /personal_access_tokens`
- [ ] [Revoke a personal access token](https://docs.gitlab.com/ee/api/personal_access_tokens.html#revoke-a-personal-access-token) `DELETE /personal_access_tokens/:id`

# [Pipelines schedules](https://docs.gitlab.com/ee/api/pipeline_schedules.html)
- [ ] [Get all pipeline schedules](https://docs.gitlab.com/ee/api/pipeline_schedules.html#get-all-pipeline-schedules) `GET /projects/:id/pipeline_schedules`
- [ ] [Get a single pipeline schedule](https://docs.gitlab.com/ee/api/pipeline_schedules.html#get-a-single-pipeline-schedule) `GET /projects/:id/pipeline_schedules/:pipeline_schedule_id`
- [ ] [Create a new pipeline schedule](https://docs.gitlab.com/ee/api/pipeline_schedules.html#create-a-new-pipeline-schedule) `POST /projects/:id/pipeline_schedules`
- [ ] [Edit a pipeline schedule](https://docs.gitlab.com/ee/api/pipeline_schedules.html#edit-a-pipeline-schedule) `PUT /projects/:id/pipeline_schedules/:pipeline_schedule_id`
- [ ] [Take ownership of a pipeline schedule](https://docs.gitlab.com/ee/api/pipeline_schedules.html#take-ownership-of-a-pipeline-schedule) `POST /projects/:id/pipeline_schedules/:pipeline_schedule_id/take_ownership`
- [ ] [Delete a pipeline schedule](https://docs.gitlab.com/ee/api/pipeline_schedules.html#delete-a-pipeline-schedule) `DELETE /projects/:id/pipeline_schedules/:pipeline_schedule_id`
- [ ] [Run a scheduled pipeline immediately](https://docs.gitlab.com/ee/api/pipeline_schedules.html#run-a-scheduled-pipeline-immediately) `POST /projects/:id/pipeline_schedules/:pipeline_schedule_id/play`
- [ ] [Create a new pipeline schedule variable](https://docs.gitlab.com/ee/api/pipeline_schedules.html#create-a-new-pipeline-schedule-variable) `POST /projects/:id/pipeline_schedules/:pipeline_schedule_id/variables`
- [ ] [Edit a pipeline schedule variable](https://docs.gitlab.com/ee/api/pipeline_schedules.html#edit-a-pipeline-schedule-variable) `PUT /projects/:id/pipeline_schedules/:pipeline_schedule_id/variables/:key`
- [ ] [Delete a pipeline schedule variable](https://docs.gitlab.com/ee/api/pipeline_schedules.html#delete-a-pipeline-schedule-variable) `DELETE /projects/:id/pipeline_schedules/:pipeline_schedule_id/variables/:key`

# [Pipeline triggers](https://docs.gitlab.com/ee/api/pipeline_triggers.html)
- [ ] [List project triggers](https://docs.gitlab.com/ee/api/pipeline_triggers.html#list-project-triggers) `GET /projects/:id/triggers`
- [ ] [Get trigger details](https://docs.gitlab.com/ee/api/pipeline_triggers.html#get-trigger-details) `GET /projects/:id/triggers/:trigger_id`
- [ ] [Create a project trigger](https://docs.gitlab.com/ee/api/pipeline_triggers.html#create-a-project-trigger) `POST /projects/:id/triggers`
- [ ] [Update a project trigger](https://docs.gitlab.com/ee/api/pipeline_triggers.html#update-a-project-trigger) `PUT /projects/:id/triggers/:trigger_id`
- [ ] [Remove a project trigger](https://docs.gitlab.com/ee/api/pipeline_triggers.html#remove-a-project-trigger) `DELETE /projects/:id/triggers/:trigger_id`

# [Pipelines](https://docs.gitlab.com/ee/api/pipelines.html)
- [ ] [List project pipelines](https://docs.gitlab.com/ee/api/pipelines.html#list-project-pipelines) `GET /projects/:id/pipelines`
- [ ] [Get a single pipeline](https://docs.gitlab.com/ee/api/pipelines.html#get-a-single-pipeline) `GET /projects/:id/pipelines/:pipeline_id`
- [ ] [Get variables of a pipeline](https://docs.gitlab.com/ee/api/pipelines.html#get-variables-of-a-pipeline) `GET /projects/:id/pipelines/:pipeline_id/variables`
- [ ] [Get a pipeline’s test report](https://docs.gitlab.com/ee/api/pipelines.html#get-a-pipelines-test-report) `GET /projects/:id/pipelines/:pipeline_id/test_report`
- [ ] [Create a new pipeline](https://docs.gitlab.com/ee/api/pipelines.html#create-a-new-pipeline) `POST /projects/:id/pipeline`
- [ ] [Retry jobs in a pipeline](https://docs.gitlab.com/ee/api/pipelines.html#retry-jobs-in-a-pipeline) `POST /projects/:id/pipelines/:pipeline_id/retry`
- [ ] [Cancel a pipeline’s jobs](https://docs.gitlab.com/ee/api/pipelines.html#cancel-a-pipelines-jobs) `POST /projects/:id/pipelines/:pipeline_id/cancel`
- [ ] [Delete a pipeline](https://docs.gitlab.com/ee/api/pipelines.html#delete-a-pipeline) `DELETE /projects/:id/pipelines/:pipeline_id`

# [Project aliases](https://docs.gitlab.com/ee/api/project_aliases.html)
- [ ] [List all project aliases](https://docs.gitlab.com/ee/api/project_aliases.html#list-all-project-aliases) `GET /project_aliases`
- [ ] [Get project alias’ details](https://docs.gitlab.com/ee/api/project_aliases.html#get-project-alias-details) `GET /project_aliases/:name`
- [ ] [Create a project alias](https://docs.gitlab.com/ee/api/project_aliases.html#create-a-project-alias) `POST /project_aliases`
- [ ] [Delete a project alias](https://docs.gitlab.com/ee/api/project_aliases.html#delete-a-project-alias) `DELETE /project_aliases/:name`

# [Project import/export](https://docs.gitlab.com/ee/api/project_import_export.html)
- [ ] [Schedule an export](https://docs.gitlab.com/ee/api/project_import_export.html#schedule-an-export) `POST /projects/:id/export`
- [ ] [Export status](https://docs.gitlab.com/ee/api/project_import_export.html#export-status) `GET /projects/:id/export`
- [ ] [Export download](https://docs.gitlab.com/ee/api/project_import_export.html#export-download) `GET /projects/:id/export/download`
- [ ] [Import a file](https://docs.gitlab.com/ee/api/project_import_export.html#import-a-file) `POST /projects/import`
- [ ] [Import status](https://docs.gitlab.com/ee/api/project_import_export.html#import-status) `GET /projects/:id/import`

# [Project repository storage moves](https://docs.gitlab.com/ee/api/project_repository_storage_moves.html)
- [ ] [Retrieve all project repository storage moves](https://docs.gitlab.com/ee/api/project_repository_storage_moves.html#retrieve-all-project-repository-storage-moves) `GET /project_repository_storage_moves`
- [ ] [Retrieve all repository storage moves for a project](https://docs.gitlab.com/ee/api/project_repository_storage_moves.html#retrieve-all-repository-storage-moves-for-a-project) `GET /projects/:project_id/repository_storage_moves`
- [ ] [Get a single project repository storage move](https://docs.gitlab.com/ee/api/project_repository_storage_moves.html#get-a-single-project-repository-storage-move) `GET /project_repository_storage_moves/:repository_storage_id`
- [ ] [Get a single repository storage move for a project](https://docs.gitlab.com/ee/api/project_repository_storage_moves.html#get-a-single-repository-storage-move-for-a-project) `GET /projects/:project_id/repository_storage_moves/:repository_storage_id`
- [ ] [Schedule a repository storage move for a project](https://docs.gitlab.com/ee/api/project_repository_storage_moves.html#schedule-a-repository-storage-move-for-a-project) `POST /projects/:project_id/repository_storage_moves`

# [Project statistics](https://docs.gitlab.com/ee/api/project_statistics.html)
- [ ] [Get the statistics of the last 30 days](https://docs.gitlab.com/ee/api/project_statistics.html#get-the-statistics-of-the-last-30-days) `GET /projects/:id/statistics`

# [Project templates](https://docs.gitlab.com/ee/api/project_templates.html)
- [ ] [Get all templates of a particular type](https://docs.gitlab.com/ee/api/project_templates.html#get-all-templates-of-a-particular-type) `GET /projects/:id/templates/:type`
- [ ] [Get one template of a particular type](https://docs.gitlab.com/ee/api/project_templates.html#get-one-template-of-a-particular-type) `GET /projects/:id/templates/:type/:key`

# [Projects](https://docs.gitlab.com/ee/api/projects.html)
- [x] [List all projects](https://docs.gitlab.com/ee/api/projects.html#list-all-projects) `GET /projects`
- [x] [List user projects](https://docs.gitlab.com/ee/api/projects.html#list-user-projects) `GET /users/:user_id/projects`
- [ ] [List projects starred by a user](https://docs.gitlab.com/ee/api/projects.html#list-projects-starred-by-a-user) `GET /users/:user_id/starred_projects`
- [x] [Get single project](https://docs.gitlab.com/ee/api/projects.html#get-single-project) `GET /projects/:id`
- [ ] [Get project users](https://docs.gitlab.com/ee/api/projects.html#get-project-users) `GET /projects/:id/users`
- [x] [Create project](https://docs.gitlab.com/ee/api/projects.html#create-project) `POST /projects`
- [ ] [Create project for user](https://docs.gitlab.com/ee/api/projects.html#create-project-for-user) `POST /projects/user/:user_id`
- [ ] [Edit project](https://docs.gitlab.com/ee/api/projects.html#edit-project) `PUT /projects/:id`
- [ ] [Fork project](https://docs.gitlab.com/ee/api/projects.html#fork-project) `POST /projects/:id/fork`
- [ ] [List Forks of a project](https://docs.gitlab.com/ee/api/projects.html#list-forks-of-a-project) `GET /projects/:id/forks`
- [ ] [Star a project](https://docs.gitlab.com/ee/api/projects.html#star-a-project) `POST /projects/:id/star`
- [ ] [Unstar a project](https://docs.gitlab.com/ee/api/projects.html#unstar-a-project) `POST /projects/:id/unstar`
- [ ] [List Starrers of a project](https://docs.gitlab.com/ee/api/projects.html#list-starrers-of-a-project) `GET /projects/:id/starrers`
- [ ] [Languages](https://docs.gitlab.com/ee/api/projects.html#languages) `GET /projects/:id/languages`
- [ ] [Archive a project](https://docs.gitlab.com/ee/api/projects.html#archive-a-project) `POST /projects/:id/archive`
- [ ] [Unarchive a project](https://docs.gitlab.com/ee/api/projects.html#unarchive-a-project) `POST /projects/:id/unarchive`
- [ ] [Delete project](https://docs.gitlab.com/ee/api/projects.html#delete-project) `DELETE /projects/:id`
- [ ] [Restore project marked for deletion](https://docs.gitlab.com/ee/api/projects.html#restore-project-marked-for-deletion-premium) `POST /projects/:id/restore`
- [ ] [Upload a file](https://docs.gitlab.com/ee/api/projects.html#upload-a-file) `POST /projects/:id/uploads`
- [ ] [Share project with group](https://docs.gitlab.com/ee/api/projects.html#share-project-with-group) `POST /projects/:id/share`
- [ ] [Delete a shared project link within a group](https://docs.gitlab.com/ee/api/projects.html#delete-a-shared-project-link-within-a-group) `DELETE /projects/:id/share/:group_id`
- [ ] [List project hooks](https://docs.gitlab.com/ee/api/projects.html#list-project-hooks) `GET /projects/:id/hooks`
- [ ] [Get project hook](https://docs.gitlab.com/ee/api/projects.html#get-project-hook) `GET /projects/:id/hooks/:hook_id`
- [ ] [Add project hook](https://docs.gitlab.com/ee/api/projects.html#add-project-hook) `POST /projects/:id/hooks`
- [ ] [Edit project hook](https://docs.gitlab.com/ee/api/projects.html#edit-project-hook) `PUT /projects/:id/hooks/:hook_id`
- [ ] [Delete project hook](https://docs.gitlab.com/ee/api/projects.html#delete-project-hook) `DELETE /projects/:id/hooks/:hook_id`
- [ ] [Create a forked from/to relation between existing projects](https://docs.gitlab.com/ee/api/projects.html#create-a-forked-fromto-relation-between-existing-projects) `POST /projects/:id/fork/:forked_from_id`
- [ ] [Delete an existing forked from relationship](https://docs.gitlab.com/ee/api/projects.html#delete-an-existing-forked-from-relationship) `DELETE /projects/:id/fork`
- [ ] [Start the Housekeeping task for a project](https://docs.gitlab.com/ee/api/projects.html#start-the-housekeeping-task-for-a-project) `POST /projects/:id/housekeeping`
- [ ] [Get project push rules](https://docs.gitlab.com/ee/api/projects.html#get-project-push-rules) `GET /projects/:id/push_rule`
- [ ] [Add project push rule](https://docs.gitlab.com/ee/api/projects.html#add-project-push-rule) `POST /projects/:id/push_rule`
- [ ] [Edit project push rule](https://docs.gitlab.com/ee/api/projects.html#edit-project-push-rule) `PUT /projects/:id/push_rule`
- [ ] [Delete project push rule](https://docs.gitlab.com/ee/api/projects.html#delete-project-push-rule) `DELETE /projects/:id/push_rule`
- [ ] [Transfer a project to a new namespace](https://docs.gitlab.com/ee/api/projects.html#transfer-a-project-to-a-new-namespace) `PUT /projects/:id/transfer`
- [ ] [Start the pull mirroring process for a Project](https://docs.gitlab.com/ee/api/projects.html#start-the-pull-mirroring-process-for-a-project-starter) `POST /projects/:id/mirror/pull`
- [ ] [Download snapshot of a Git repository](https://docs.gitlab.com/ee/api/projects.html#download-snapshot-of-a-git-repository) `GET /projects/:id/snapshot`

# [Protected branches](https://docs.gitlab.com/ee/api/protected_branches.html)
- [ ] [List protected branches](https://docs.gitlab.com/ee/api/protected_branches.html#list-protected-branches) `GET /projects/:id/protected_branches`
- [ ] [Get a single protected branch or wildcard protected branch](https://docs.gitlab.com/ee/api/protected_branches.html#get-a-single-protected-branch-or-wildcard-protected-branch) `GET /projects/:id/protected_branches/:name`
- [ ] [Protect repository branches](https://docs.gitlab.com/ee/api/protected_branches.html#protect-repository-branches) `POST /projects/:id/protected_branches`
- [ ] [Unprotect repository branches](https://docs.gitlab.com/ee/api/protected_branches.html#unprotect-repository-branches) `DELETE /projects/:id/protected_branches/:name`
- [ ] [Require code owner approvals for a single branch](https://docs.gitlab.com/ee/api/protected_branches.html#require-code-owner-approvals-for-a-single-branch) `PATCH /projects/:id/protected_branches/:name`

# [Protected tags](https://docs.gitlab.com/ee/api/protected_tags.html)
- [ ] [List protected tags](https://docs.gitlab.com/ee/api/protected_tags.html#list-protected-tags) `GET /projects/:id/protected_tags`
- [ ] [Get a single protected tag or wildcard protected tag](https://docs.gitlab.com/ee/api/protected_tags.html#get-a-single-protected-tag-or-wildcard-protected-tag) `GET /projects/:id/protected_tags/:name`
- [ ] [Protect repository tags](https://docs.gitlab.com/ee/api/protected_tags.html#protect-repository-tags) `POST /projects/:id/protected_tags`
- [ ] [Unprotect repository tags](https://docs.gitlab.com/ee/api/protected_tags.html#unprotect-repository-tags) `DELETE /projects/:id/protected_tags/:name`

# [Releases](https://docs.gitlab.com/ee/api/releases/)
- [ ] [List Releases](https://docs.gitlab.com/ee/api/releases/#list-releases) `GET /projects/:id/releases`
- [ ] [Get a Release by a tag name](https://docs.gitlab.com/ee/api/releases/#get-a-release-by-a-tag-name) `GET /projects/:id/releases/:tag_name`
- [ ] [Create a release](https://docs.gitlab.com/ee/api/releases/#create-a-release) `POST /projects/:id/releases`
- [ ] [Collect release evidence](https://docs.gitlab.com/ee/api/releases/#collect-release-evidence-premium-only) `POST /projects/:id/releases/:tag_name/evidence`
- [ ] [Update a release](https://docs.gitlab.com/ee/api/releases/#update-a-release) `PUT /projects/:id/releases/:tag_name`
- [ ] [Delete a Release](https://docs.gitlab.com/ee/api/releases/#delete-a-release) `DELETE /projects/:id/releases/:tag_name`

# [Release links](https://docs.gitlab.com/ee/api/releases/links.html)
- [ ] [Get links](https://docs.gitlab.com/ee/api/releases/links.html#get-links) `GET /projects/:id/releases/:tag_name/assets/links`
- [ ] [Get a link](https://docs.gitlab.com/ee/api/releases/links.html#get-a-link) `GET /projects/:id/releases/:tag_name/assets/links/:link_id`
- [ ] [Create a link](https://docs.gitlab.com/ee/api/releases/links.html#create-a-link) `POST /projects/:id/releases/:tag_name/assets/links`
- [ ] [Update a link](https://docs.gitlab.com/ee/api/releases/links.html#update-a-link) `PUT /projects/:id/releases/:tag_name/assets/links/:link_id`
- [ ] [Delete a link](https://docs.gitlab.com/ee/api/releases/links.html#delete-a-link) `DELETE /projects/:id/releases/:tag_name/assets/links/:link_id`

# [Repositories](https://docs.gitlab.com/ee/api/repositories.html)
- [ ] [List repository tree](https://docs.gitlab.com/ee/api/repositories.html#list-repository-tree) `GET /projects/:id/repository/tree`
- [ ] [Get a blob from repository](https://docs.gitlab.com/ee/api/repositories.html#get-a-blob-from-repository) `GET /projects/:id/repository/blobs/:sha`
- [ ] [Raw blob content](https://docs.gitlab.com/ee/api/repositories.html#raw-blob-content) `GET /projects/:id/repository/blobs/:sha/raw`
- [ ] [Get file archive](https://docs.gitlab.com/ee/api/repositories.html#get-file-archive) `GET /projects/:id/repository/archive[.format]`
- [ ] [Compare branches, tags or commits](https://docs.gitlab.com/ee/api/repositories.html#compare-branches-tags-or-commits) `GET /projects/:id/repository/compare`
- [ ] [Contributors](https://docs.gitlab.com/ee/api/repositories.html#contributors) `GET /projects/:id/repository/contributors`
- [ ] [Merge Base](https://docs.gitlab.com/ee/api/repositories.html#merge-base) `GET /projects/:id/repository/merge_base`

# [Repository files](https://docs.gitlab.com/ee/api/repository_files.html)
- [ ] [Get file from repository](https://docs.gitlab.com/ee/api/repository_files.html#get-file-from-repository) `GET /projects/:id/repository/files/:file_path`
- [ ] [Get file blame from repository](https://docs.gitlab.com/ee/api/repository_files.html#get-file-blame-from-repository) `GET /projects/:id/repository/files/:file_path/blame`
- [ ] [Get raw file from repository](https://docs.gitlab.com/ee/api/repository_files.html#get-raw-file-from-repository) `GET /projects/:id/repository/files/:file_path/raw`
- [x] [Create new file in repository](https://docs.gitlab.com/ee/api/repository_files.html#create-new-file-in-repository) `POST /projects/:id/repository/files/:file_path`
- [x] [Update existing file in repository](https://docs.gitlab.com/ee/api/repository_files.html#update-existing-file-in-repository) `PUT /projects/:id/repository/files/:file_path`
- [ ] [Delete existing file in repository](https://docs.gitlab.com/ee/api/repository_files.html#delete-existing-file-in-repository) `DELETE /projects/:id/repository/files/:file_path`

# [Repository submodules](https://docs.gitlab.com/ee/api/repository_submodules.html)
- [ ] [Update existing submodule reference in repository](https://docs.gitlab.com/ee/api/repository_submodules.html#update-existing-submodule-reference-in-repository) `PUT /projects/:id/repository/submodules/:submodule`

# [Resource label events](https://docs.gitlab.com/ee/api/resource_label_events.html)
- [ ] [List project issue label events](https://docs.gitlab.com/ee/api/resource_label_events.html#list-project-issue-label-events) `GET /projects/:id/issues/:issue_iid/resource_label_events`
- [ ] [Get single issue label event](https://docs.gitlab.com/ee/api/resource_label_events.html#get-single-issue-label-event) `GET /projects/:id/issues/:issue_iid/resource_label_events/:resource_label_event_id`
- [ ] [List group epic label events](https://docs.gitlab.com/ee/api/resource_label_events.html#list-group-epic-label-events) `GET /groups/:id/epics/:epic_id/resource_label_events`
- [ ] [Get single epic label event](https://docs.gitlab.com/ee/api/resource_label_events.html#get-single-epic-label-event) `GET /groups/:id/epics/:epic_id/resource_label_events/:resource_label_event_id`
- [ ] [List project merge request label events](https://docs.gitlab.com/ee/api/resource_label_events.html#list-project-merge-request-label-events) `GET /projects/:id/merge_requests/:merge_request_iid/resource_label_events`
- [ ] [Get single merge request label event](https://docs.gitlab.com/ee/api/resource_label_events.html#get-single-merge-request-label-event) `GET /projects/:id/merge_requests/:merge_request_iid/resource_label_events/:resource_label_event_id`

# [Resource milestone events](https://docs.gitlab.com/ee/api/resource_milestone_events.html)
- [ ] [List project issue milestone events](https://docs.gitlab.com/ee/api/resource_milestone_events.html#list-project-issue-milestone-events) `GET /projects/:id/issues/:issue_iid/resource_milestone_events`
- [ ] [Get single issue milestone event](https://docs.gitlab.com/ee/api/resource_milestone_events.html#get-single-issue-milestone-event) `GET /projects/:id/issues/:issue_iid/resource_milestone_events/:resource_milestone_event_id`
- [ ] [List project merge request milestone events](https://docs.gitlab.com/ee/api/resource_milestone_events.html#list-project-merge-request-milestone-events) `GET /projects/:id/merge_requests/:merge_request_iid/resource_milestone_events`
- [ ] [Get single merge request milestone event](https://docs.gitlab.com/ee/api/resource_milestone_events.html#get-single-merge-request-milestone-event) `GET /projects/:id/merge_requests/:merge_request_iid/resource_milestone_events/:resource_milestone_event_id`

# [Resource state events](https://docs.gitlab.com/ee/api/resource_state_events.html)
- [ ] [List project issue state events](https://docs.gitlab.com/ee/api/resource_state_events.html#list-project-issue-state-events) `GET /projects/:id/issues/:issue_iid/resource_state_events`
- [ ] [Get single issue state event](https://docs.gitlab.com/ee/api/resource_state_events.html#get-single-issue-state-event) `GET /projects/:id/issues/:issue_iid/resource_state_events/:resource_state_event_id`
- [ ] [List project merge request state events](https://docs.gitlab.com/ee/api/resource_state_events.html#list-project-merge-request-state-events) `GET /projects/:id/merge_requests/:merge_request_iid/resource_state_events`
- [ ] [Get single merge request state event](https://docs.gitlab.com/ee/api/resource_state_events.html#get-single-merge-request-state-event) `GET /projects/:id/merge_requests/:merge_request_iid/resource_state_events/:resource_state_event_id`

# [Resource weight events](https://docs.gitlab.com/ee/api/resource_weight_events.html)
- [ ] [List project issue weight events](https://docs.gitlab.com/ee/api/resource_weight_events.html#list-project-issue-weight-events) `GET /projects/:id/issues/:issue_iid/resource_weight_events`
- [ ] [Get single issue weight event](https://docs.gitlab.com/ee/api/resource_weight_events.html#get-single-issue-weight-event) `GET /projects/:id/issues/:issue_iid/resource_weight_events/:resource_weight_event_id`

# [Runners](https://docs.gitlab.com/ee/api/runners.html)
- [ ] [List owned runners](https://docs.gitlab.com/ee/api/runners.html#list-owned-runners) `GET /runners`
- [ ] [List all runners](https://docs.gitlab.com/ee/api/runners.html#list-all-runners) `GET /runners/all`
- [ ] [Get runner’s details](https://docs.gitlab.com/ee/api/runners.html#get-runners-details) `GET /runners/:id`
- [ ] [Update runner’s details](https://docs.gitlab.com/ee/api/runners.html#update-runners-details) `PUT /runners/:id`
- [ ] [Remove a runner](https://docs.gitlab.com/ee/api/runners.html#remove-a-runner) `DELETE /runners/:id`
- [ ] [List runner’s jobs](https://docs.gitlab.com/ee/api/runners.html#list-runners-jobs) `GET /runners/:id/jobs`
- [ ] [List project’s runners](https://docs.gitlab.com/ee/api/runners.html#list-projects-runners) `GET /projects/:id/runners`
- [ ] [Enable a runner in project](https://docs.gitlab.com/ee/api/runners.html#enable-a-runner-in-project) `POST /projects/:id/runners`
- [ ] [Disable a runner from project](https://docs.gitlab.com/ee/api/runners.html#disable-a-runner-from-project) `DELETE /projects/:id/runners/:runner_id`
- [ ] [List group’s runners](https://docs.gitlab.com/ee/api/runners.html#list-groups-runners) `GET /groups/:id/runners`
- [ ] [Register a new runner](https://docs.gitlab.com/ee/api/runners.html#register-a-new-runner) `POST /runners`
- [ ] [Delete a registered runner](https://docs.gitlab.com/ee/api/runners.html#delete-a-registered-runner) `DELETE /runners`
- [ ] [Verify authentication for a registered runner](https://docs.gitlab.com/ee/api/runners.html#verify-authentication-for-a-registered-runner) `POST /runners/verify`

# [SCIM](https://docs.gitlab.com/ee/api/scim.html)
- [ ] [Get a list of SAML users](https://docs.gitlab.com/ee/api/scim.html#get-a-list-of-saml-users) `GET /api/scim/v2/groups/:group_path/Users`
- [ ] [Get a single SAML user](https://docs.gitlab.com/ee/api/scim.html#get-a-single-saml-user) `GET /api/scim/v2/groups/:group_path/Users/:id`
- [ ] [Create a SAML user](https://docs.gitlab.com/ee/api/scim.html#create-a-saml-user) `POST /api/scim/v2/groups/:group_path/Users/`
- [ ] [Update a single SAML user](https://docs.gitlab.com/ee/api/scim.html#update-a-single-saml-user) `PATCH /api/scim/v2/groups/:group_path/Users/:id`
- [ ] [Remove a single SAML user](https://docs.gitlab.com/ee/api/scim.html#remove-a-single-saml-user) `DELETE /api/scim/v2/groups/:group_path/Users/:id`

# [Search](https://docs.gitlab.com/ee/api/search.html)
- [ ] [Global Search API](https://docs.gitlab.com/ee/api/search.html#global-search-api) `GET /search`
- [ ] [Group Search API](https://docs.gitlab.com/ee/api/search.html#group-search-api) `GET /groups/:id/search`
- [ ] [Project Search API](https://docs.gitlab.com/ee/api/search.html#project-search-api) `GET /projects/:id/search`

# [Services](https://docs.gitlab.com/ee/api/services.html)
- [ ] [List all active services](https://docs.gitlab.com/ee/api/services.html#list-all-active-services) `GET /projects/:id/services`
- [ ] [Create/Edit Asana service](https://docs.gitlab.com/ee/api/services.html#createedit-asana-service) `PUT /projects/:id/services/asana`
- [ ] [Delete Asana service](https://docs.gitlab.com/ee/api/services.html#delete-asana-service) `DELETE /projects/:id/services/asana`
- [ ] [Get Asana service settings](https://docs.gitlab.com/ee/api/services.html#get-asana-service-settings) `GET /projects/:id/services/asana`
- [ ] [Create/Edit Assembla service](https://docs.gitlab.com/ee/api/services.html#createedit-assembla-service) `PUT /projects/:id/services/assembla`
- [ ] [Delete Assembla service](https://docs.gitlab.com/ee/api/services.html#delete-assembla-service) `DELETE /projects/:id/services/assembla`
- [ ] [Get Assembla service settings](https://docs.gitlab.com/ee/api/services.html#get-assembla-service-settings) `GET /projects/:id/services/assembla`
- [ ] [Create/Edit Atlassian Bamboo CI service](https://docs.gitlab.com/ee/api/services.html#createedit-atlassian-bamboo-ci-service) `PUT /projects/:id/services/bamboo`
- [ ] [Delete Atlassian Bamboo CI service](https://docs.gitlab.com/ee/api/services.html#delete-atlassian-bamboo-ci-service) `DELETE /projects/:id/services/bamboo`
- [ ] [Get Atlassian Bamboo CI service settings](https://docs.gitlab.com/ee/api/services.html#get-atlassian-bamboo-ci-service-settings) `GET /projects/:id/services/bamboo`
- [ ] [Create/Edit Bugzilla service](https://docs.gitlab.com/ee/api/services.html#createedit-bugzilla-service) `PUT /projects/:id/services/bugzilla`
- [ ] [Delete Bugzilla Service](https://docs.gitlab.com/ee/api/services.html#delete-bugzilla-service) `DELETE /projects/:id/services/bugzilla`
- [ ] [Get Bugzilla Service Settings](https://docs.gitlab.com/ee/api/services.html#get-bugzilla-service-settings) `GET /projects/:id/services/bugzilla`
- [ ] [Create/Edit Buildkite service](https://docs.gitlab.com/ee/api/services.html#createedit-buildkite-service) `PUT /projects/:id/services/buildkite`
- [ ] [Delete Buildkite service](https://docs.gitlab.com/ee/api/services.html#delete-buildkite-service) `DELETE /projects/:id/services/buildkite`
- [ ] [Get Buildkite service settings](https://docs.gitlab.com/ee/api/services.html#get-buildkite-service-settings) `GET /projects/:id/services/buildkite`
- [ ] [Create/Edit Campfire service](https://docs.gitlab.com/ee/api/services.html#createedit-campfire-service) `PUT /projects/:id/services/campfire`
- [ ] [Delete Campfire service](https://docs.gitlab.com/ee/api/services.html#delete-campfire-service) `DELETE /projects/:id/services/campfire`
- [ ] [Get Campfire service settings](https://docs.gitlab.com/ee/api/services.html#get-campfire-service-settings) `GET /projects/:id/services/campfire`
- [ ] [Create/Edit Unify Circuit service](https://docs.gitlab.com/ee/api/services.html#createedit-unify-circuit-service) `PUT /projects/:id/services/unify-circuit`
- [ ] [Delete Unify Circuit service](https://docs.gitlab.com/ee/api/services.html#delete-unify-circuit-service) `DELETE /projects/:id/services/unify-circuit`
- [ ] [Get Unify Circuit service settings](https://docs.gitlab.com/ee/api/services.html#get-unify-circuit-service-settings) `GET /projects/:id/services/unify-circuit`
- [ ] [Create/Edit Webex Teams service](https://docs.gitlab.com/ee/api/services.html#createedit-webex-teams-service) `PUT /projects/:id/services/webex-teams`
- [ ] [Delete Webex Teams service](https://docs.gitlab.com/ee/api/services.html#delete-webex-teams-service) `DELETE /projects/:id/services/webex-teams`
- [ ] [Get Webex Teams service settings](https://docs.gitlab.com/ee/api/services.html#get-webex-teams-service-settings) `GET /projects/:id/services/webex-teams`
- [ ] [Create/Edit Custom Issue Tracker service](https://docs.gitlab.com/ee/api/services.html#createedit-custom-issue-tracker-service) `PUT /projects/:id/services/custom-issue-tracker`
- [ ] [Delete Custom Issue Tracker service](https://docs.gitlab.com/ee/api/services.html#delete-custom-issue-tracker-service) `DELETE /projects/:id/services/custom-issue-tracker`
- [ ] [Get Custom Issue Tracker service settings](https://docs.gitlab.com/ee/api/services.html#get-custom-issue-tracker-service-settings) `GET /projects/:id/services/custom-issue-tracker`
- [ ] [Create/Edit Drone CI service](https://docs.gitlab.com/ee/api/services.html#createedit-drone-ci-service) `PUT /projects/:id/services/drone-ci`
- [ ] [Delete Drone CI service](https://docs.gitlab.com/ee/api/services.html#delete-drone-ci-service) `DELETE /projects/:id/services/drone-ci`
- [ ] [Get Drone CI service settings](https://docs.gitlab.com/ee/api/services.html#get-drone-ci-service-settings) `GET /projects/:id/services/drone-ci`
- [ ] [Create/Edit Emails on push service](https://docs.gitlab.com/ee/api/services.html#createedit-emails-on-push-service) `PUT /projects/:id/services/emails-on-push`
- [ ] [Delete Emails on push service](https://docs.gitlab.com/ee/api/services.html#delete-emails-on-push-service) `DELETE /projects/:id/services/emails-on-push`
- [ ] [Get Emails on push service settings](https://docs.gitlab.com/ee/api/services.html#get-emails-on-push-service-settings) `GET /projects/:id/services/emails-on-push`
- [ ] [Create/Edit Confluence service](https://docs.gitlab.com/ee/api/services.html#createedit-confluence-service) `PUT /projects/:id/services/confluence`
- [ ] [Delete Confluence service](https://docs.gitlab.com/ee/api/services.html#delete-confluence-service) `DELETE /projects/:id/services/confluence`
- [ ] [Get Confluence service settings](https://docs.gitlab.com/ee/api/services.html#get-confluence-service-settings) `GET /projects/:id/services/confluence`
- [ ] [Create/Edit External Wiki service](https://docs.gitlab.com/ee/api/services.html#createedit-external-wiki-service) `PUT /projects/:id/services/external-wiki`
- [ ] [Delete External Wiki service](https://docs.gitlab.com/ee/api/services.html#delete-external-wiki-service) `DELETE /projects/:id/services/external-wiki`
- [ ] [Get External Wiki service settings](https://docs.gitlab.com/ee/api/services.html#get-external-wiki-service-settings) `GET /projects/:id/services/external-wiki`
- [ ] [Create/Edit Flowdock service](https://docs.gitlab.com/ee/api/services.html#createedit-flowdock-service) `PUT /projects/:id/services/flowdock`
- [ ] [Delete Flowdock service](https://docs.gitlab.com/ee/api/services.html#delete-flowdock-service) `DELETE /projects/:id/services/flowdock`
- [ ] [Get Flowdock service settings](https://docs.gitlab.com/ee/api/services.html#get-flowdock-service-settings) `GET /projects/:id/services/flowdock`
- [ ] [Create/Edit GitHub service](https://docs.gitlab.com/ee/api/services.html#createedit-github-service) `PUT /projects/:id/services/github`
- [ ] [Delete GitHub service](https://docs.gitlab.com/ee/api/services.html#delete-github-service) `DELETE /projects/:id/services/github`
- [ ] [Get GitHub service settings](https://docs.gitlab.com/ee/api/services.html#get-github-service-settings) `GET /projects/:id/services/github`
- [ ] [Create/Edit Hangouts Chat service](https://docs.gitlab.com/ee/api/services.html#createedit-hangouts-chat-service) `PUT /projects/:id/services/hangouts-chat`
- [ ] [Delete Hangouts Chat service](https://docs.gitlab.com/ee/api/services.html#delete-hangouts-chat-service) `DELETE /projects/:id/services/hangouts-chat`
- [ ] [Get Hangouts Chat service settings](https://docs.gitlab.com/ee/api/services.html#get-hangouts-chat-service-settings) `GET /projects/:id/services/hangouts-chat`
- [ ] [Create/Edit HipChat service](https://docs.gitlab.com/ee/api/services.html#createedit-hipchat-service) `PUT /projects/:id/services/hipchat`
- [ ] [Delete HipChat service](https://docs.gitlab.com/ee/api/services.html#delete-hipchat-service) `DELETE /projects/:id/services/hipchat`
- [ ] [Get HipChat service settings](https://docs.gitlab.com/ee/api/services.html#get-hipchat-service-settings) `GET /projects/:id/services/hipchat`
- [ ] [Create/Edit Irker (IRC gateway) service](https://docs.gitlab.com/ee/api/services.html#createedit-irker-irc-gateway-service) `PUT /projects/:id/services/irker`
- [ ] [Delete Irker (IRC gateway) service](https://docs.gitlab.com/ee/api/services.html#delete-irker-irc-gateway-service) `DELETE /projects/:id/services/irker`
- [ ] [Get Irker (IRC gateway) service settings](https://docs.gitlab.com/ee/api/services.html#get-irker-irc-gateway-service-settings) `GET /projects/:id/services/irker`
- [ ] [Get Jira service settings](https://docs.gitlab.com/ee/api/services.html#get-jira-service-settings) `GET /projects/:id/services/jira`
- [ ] [Create/Edit Jira service](https://docs.gitlab.com/ee/api/services.html#createedit-jira-service) `PUT /projects/:id/services/jira`
- [ ] [Delete Jira service](https://docs.gitlab.com/ee/api/services.html#delete-jira-service) `DELETE /projects/:id/services/jira`
- [ ] [Get Slack slash command service settings](https://docs.gitlab.com/ee/api/services.html#get-slack-slash-command-service-settings) `GET /projects/:id/services/slack-slash-commands`
- [ ] [Create/Edit Slack slash command service](https://docs.gitlab.com/ee/api/services.html#createedit-slack-slash-command-service) `PUT /projects/:id/services/slack-slash-commands`
- [ ] [Delete Slack slash command service](https://docs.gitlab.com/ee/api/services.html#delete-slack-slash-command-service) `DELETE /projects/:id/services/slack-slash-commands`
- [ ] [Get Mattermost slash command service settings](https://docs.gitlab.com/ee/api/services.html#get-mattermost-slash-command-service-settings) `GET /projects/:id/services/mattermost-slash-commands`
- [ ] [Create/Edit Mattermost slash command service](https://docs.gitlab.com/ee/api/services.html#createedit-mattermost-slash-command-service) `PUT /projects/:id/services/mattermost-slash-commands`
- [ ] [Delete Mattermost slash command service](https://docs.gitlab.com/ee/api/services.html#delete-mattermost-slash-command-service) `DELETE /projects/:id/services/mattermost-slash-commands`
- [ ] [Create/Edit Packagist service](https://docs.gitlab.com/ee/api/services.html#createedit-packagist-service) `PUT /projects/:id/services/packagist`
- [ ] [Delete Packagist service](https://docs.gitlab.com/ee/api/services.html#delete-packagist-service) `DELETE /projects/:id/services/packagist`
- [ ] [Get Packagist service settings](https://docs.gitlab.com/ee/api/services.html#get-packagist-service-settings) `GET /projects/:id/services/packagist`
- [ ] [Create/Edit Pipeline-Emails service](https://docs.gitlab.com/ee/api/services.html#createedit-pipeline-emails-service) `PUT /projects/:id/services/pipelines-email`
- [ ] [Delete Pipeline-Emails service](https://docs.gitlab.com/ee/api/services.html#delete-pipeline-emails-service) `DELETE /projects/:id/services/pipelines-email`
- [ ] [Get Pipeline-Emails service settings](https://docs.gitlab.com/ee/api/services.html#get-pipeline-emails-service-settings) `GET /projects/:id/services/pipelines-email`
- [ ] [Create/Edit PivotalTracker service](https://docs.gitlab.com/ee/api/services.html#createedit-pivotaltracker-service) `PUT /projects/:id/services/pivotaltracker`
- [ ] [Delete PivotalTracker service](https://docs.gitlab.com/ee/api/services.html#delete-pivotaltracker-service) `DELETE /projects/:id/services/pivotaltracker`
- [ ] [Get PivotalTracker service settings](https://docs.gitlab.com/ee/api/services.html#get-pivotaltracker-service-settings) `GET /projects/:id/services/pivotaltracker`
- [ ] [Create/Edit Prometheus service](https://docs.gitlab.com/ee/api/services.html#createedit-prometheus-service) `PUT /projects/:id/services/prometheus`
- [ ] [Delete Prometheus service](https://docs.gitlab.com/ee/api/services.html#delete-prometheus-service) `DELETE /projects/:id/services/prometheus`
- [ ] [Get Prometheus service settings](https://docs.gitlab.com/ee/api/services.html#get-prometheus-service-settings) `GET /projects/:id/services/prometheus`
- [ ] [Create/Edit Pushover service](https://docs.gitlab.com/ee/api/services.html#createedit-pushover-service) `PUT /projects/:id/services/pushover`
- [ ] [Delete Pushover service](https://docs.gitlab.com/ee/api/services.html#delete-pushover-service) `DELETE /projects/:id/services/pushover`
- [ ] [Get Pushover service settings](https://docs.gitlab.com/ee/api/services.html#get-pushover-service-settings) `GET /projects/:id/services/pushover`
- [ ] [Create/Edit Redmine service](https://docs.gitlab.com/ee/api/services.html#createedit-redmine-service) `PUT /projects/:id/services/redmine`
- [ ] [Delete Redmine service](https://docs.gitlab.com/ee/api/services.html#delete-redmine-service) `DELETE /projects/:id/services/redmine`
- [ ] [Get Redmine service settings](https://docs.gitlab.com/ee/api/services.html#get-redmine-service-settings) `GET /projects/:id/services/redmine`
- [ ] [Create/Edit Slack service](https://docs.gitlab.com/ee/api/services.html#createedit-slack-service) `PUT /projects/:id/services/slack`
- [ ] [Delete Slack service](https://docs.gitlab.com/ee/api/services.html#delete-slack-service) `DELETE /projects/:id/services/slack`
- [ ] [Get Slack service settings](https://docs.gitlab.com/ee/api/services.html#get-slack-service-settings) `GET /projects/:id/services/slack`
- [ ] [Create/Edit Microsoft Teams service](https://docs.gitlab.com/ee/api/services.html#createedit-microsoft-teams-service) `PUT /projects/:id/services/microsoft-teams`
- [ ] [Delete Microsoft Teams service](https://docs.gitlab.com/ee/api/services.html#delete-microsoft-teams-service) `DELETE /projects/:id/services/microsoft-teams`
- [ ] [Get Microsoft Teams service settings](https://docs.gitlab.com/ee/api/services.html#get-microsoft-teams-service-settings) `GET /projects/:id/services/microsoft-teams`
- [ ] [Create/Edit Mattermost notifications service](https://docs.gitlab.com/ee/api/services.html#createedit-mattermost-notifications-service) `PUT /projects/:id/services/mattermost`
- [ ] [Delete Mattermost notifications service](https://docs.gitlab.com/ee/api/services.html#delete-mattermost-notifications-service) `DELETE /projects/:id/services/mattermost`
- [ ] [Get Mattermost notifications service settings](https://docs.gitlab.com/ee/api/services.html#get-mattermost-notifications-service-settings) `GET /projects/:id/services/mattermost`
- [ ] [Create/Edit JetBrains TeamCity CI service](https://docs.gitlab.com/ee/api/services.html#createedit-jetbrains-teamcity-ci-service) `PUT /projects/:id/services/teamcity`
- [ ] [Delete JetBrains TeamCity CI service](https://docs.gitlab.com/ee/api/services.html#delete-jetbrains-teamcity-ci-service) `DELETE /projects/:id/services/teamcity`
- [ ] [Get JetBrains TeamCity CI service settings](https://docs.gitlab.com/ee/api/services.html#get-jetbrains-teamcity-ci-service-settings) `GET /projects/:id/services/teamcity`
- [ ] [Create/Edit Jenkins CI service](https://docs.gitlab.com/ee/api/services.html#createedit-jenkins-ci-service) `PUT /projects/:id/services/jenkins`
- [ ] [Delete Jenkins CI service](https://docs.gitlab.com/ee/api/services.html#delete-jenkins-ci-service) `DELETE /projects/:id/services/jenkins`
- [ ] [Get Jenkins CI service settings](https://docs.gitlab.com/ee/api/services.html#get-jenkins-ci-service-settings) `GET /projects/:id/services/jenkins`
- [ ] [Create/Edit Jenkins CI (Deprecated) service](https://docs.gitlab.com/ee/api/services.html#createedit-jenkins-ci-deprecated-service) `PUT /projects/:id/services/jenkins-deprecated`
- [ ] [Delete Jenkins CI (Deprecated) service](https://docs.gitlab.com/ee/api/services.html#delete-jenkins-ci-deprecated-service) `DELETE /projects/:id/services/jenkins-deprecated`
- [ ] [Get Jenkins CI (Deprecated) service settings](https://docs.gitlab.com/ee/api/services.html#get-jenkins-ci-deprecated-service-settings) `GET /projects/:id/services/jenkins-deprecated`
- [ ] [Create/Edit MockCI service](https://docs.gitlab.com/ee/api/services.html#createedit-mockci-service) `PUT /projects/:id/services/mock-ci`
- [ ] [Delete MockCI service](https://docs.gitlab.com/ee/api/services.html#delete-mockci-service) `DELETE /projects/:id/services/mock-ci`
- [ ] [Get MockCI service settings](https://docs.gitlab.com/ee/api/services.html#get-mockci-service-settings) `GET /projects/:id/services/mock-ci`
- [ ] [Create/Edit YouTrack service](https://docs.gitlab.com/ee/api/services.html#createedit-youtrack-service) `PUT /projects/:id/services/youtrack`
- [ ] [Delete YouTrack Service](https://docs.gitlab.com/ee/api/services.html#delete-youtrack-service) `DELETE /projects/:id/services/youtrack`
- [ ] [Get YouTrack Service Settings](https://docs.gitlab.com/ee/api/services.html#get-youtrack-service-settings) `GET /projects/:id/services/youtrack`

# [Settings (application)](https://docs.gitlab.com/ee/api/settings.html)
- [ ] [Get current application settings](https://docs.gitlab.com/ee/api/settings.html#get-current-application-settings) `GET /application/settings`
- [ ] [Change application settings](https://docs.gitlab.com/ee/api/settings.html#change-application-settings) `PUT /application/settings`

# [Sidekiq metrics](https://docs.gitlab.com/ee/api/sidekiq_metrics.html)
- [ ] [Get the current Queue Metrics](https://docs.gitlab.com/ee/api/sidekiq_metrics.html#get-the-current-queue-metrics) `GET /sidekiq/queue_metrics`
- [ ] [Get the current Process Metrics](https://docs.gitlab.com/ee/api/sidekiq_metrics.html#get-the-current-process-metrics) `GET /sidekiq/process_metrics`
- [ ] [Get the current Job Statistics](https://docs.gitlab.com/ee/api/sidekiq_metrics.html#get-the-current-job-statistics) `GET /sidekiq/job_stats`
- [ ] [Get a compound response of all the previously mentioned metrics](https://docs.gitlab.com/ee/api/sidekiq_metrics.html#get-a-compound-response-of-all-the-previously-mentioned-metrics) `GET /sidekiq/compound_metrics`

# [Snippets](https://docs.gitlab.com/ee/api/snippets.html)
- [ ] [List all snippets for a user](https://docs.gitlab.com/ee/api/snippets.html#list-all-snippets-for-a-user) `GET /snippets`
- [ ] [Get a single snippet](https://docs.gitlab.com/ee/api/snippets.html#get-a-single-snippet) `GET /snippets/:id`
- [ ] [Single snippet contents](https://docs.gitlab.com/ee/api/snippets.html#single-snippet-contents) `GET /snippets/:id/raw`
- [ ] [Snippet repository file content](https://docs.gitlab.com/ee/api/snippets.html#snippet-repository-file-content) `GET /snippets/:id/files/:ref/:file_path/raw`
- [ ] [Create new snippet](https://docs.gitlab.com/ee/api/snippets.html#create-new-snippet) `POST /snippets`
- [ ] [Update snippet](https://docs.gitlab.com/ee/api/snippets.html#update-snippet) `PUT /snippets/:id`
- [ ] [Delete snippet](https://docs.gitlab.com/ee/api/snippets.html#delete-snippet) `DELETE /snippets/:id`
- [ ] [List all public snippets](https://docs.gitlab.com/ee/api/snippets.html#list-all-public-snippets) `GET /snippets/public`
- [ ] [Get user agent details](https://docs.gitlab.com/ee/api/snippets.html#get-user-agent-details) `GET /snippets/:id/user_agent_detail`

# [Snippets (project)](https://docs.gitlab.com/ee/api/project_snippets.html)
- [ ] [List snippets](https://docs.gitlab.com/ee/api/project_snippets.html#list-snippets) `GET /projects/:id/snippets`
- [ ] [Single snippet](https://docs.gitlab.com/ee/api/project_snippets.html#single-snippet) `GET /projects/:id/snippets/:snippet_id`
- [ ] [Create new snippet](https://docs.gitlab.com/ee/api/project_snippets.html#create-new-snippet) `POST /projects/:id/snippets`
- [ ] [Update snippet](https://docs.gitlab.com/ee/api/project_snippets.html#update-snippet) `PUT /projects/:id/snippets/:snippet_id`
- [ ] [Delete snippet](https://docs.gitlab.com/ee/api/project_snippets.html#delete-snippet) `DELETE /projects/:id/snippets/:snippet_id`
- [ ] [Snippet content](https://docs.gitlab.com/ee/api/project_snippets.html#snippet-content) `GET /projects/:id/snippets/:snippet_id/raw`
- [ ] [Snippet repository file content](https://docs.gitlab.com/ee/api/project_snippets.html#snippet-repository-file-content) `GET /projects/:id/snippets/:snippet_id/files/:ref/:file_path/raw`
- [ ] [Get user agent details](https://docs.gitlab.com/ee/api/project_snippets.html#get-user-agent-details) `GET /projects/:id/snippets/:snippet_id/user_agent_detail`

# [Statistics (application)](https://docs.gitlab.com/ee/api/statistics.html)
- [ ] [Get current application statistics](https://docs.gitlab.com/ee/api/statistics.html#get-current-application-statistics) `GET /application/statistics`

# [Suggestions](https://docs.gitlab.com/ee/api/suggestions.html)
- [ ] [Applying suggestions](https://docs.gitlab.com/ee/api/suggestions.html#applying-suggestions) `PUT /suggestions/:id/apply`

# [System hooks](https://docs.gitlab.com/ee/api/system_hooks.html)
- [ ] [List system hooks](https://docs.gitlab.com/ee/api/system_hooks.html#list-system-hooks) `GET /hooks`
- [ ] [Add new system hook](https://docs.gitlab.com/ee/api/system_hooks.html#add-new-system-hook) `POST /hooks`
- [ ] [Test system hook](https://docs.gitlab.com/ee/api/system_hooks.html#test-system-hook) `GET /hooks/:id`
- [ ] [Delete system hook](https://docs.gitlab.com/ee/api/system_hooks.html#delete-system-hook) `DELETE /hooks/:id`

# [Tags](https://docs.gitlab.com/ee/api/tags.html)
- [ ] [List project repository tags](https://docs.gitlab.com/ee/api/tags.html#list-project-repository-tags) `GET /projects/:id/repository/tags`
- [ ] [Get a single repository tag](https://docs.gitlab.com/ee/api/tags.html#get-a-single-repository-tag) `GET /projects/:id/repository/tags/:tag_name`
- [ ] [Create a new tag](https://docs.gitlab.com/ee/api/tags.html#create-a-new-tag) `POST /projects/:id/repository/tags`
- [ ] [Delete a tag](https://docs.gitlab.com/ee/api/tags.html#delete-a-tag) `DELETE /projects/:id/repository/tags/:tag_name`
- [ ] [Create a new release](https://docs.gitlab.com/ee/api/tags.html#create-a-new-release) `POST /projects/:id/repository/tags/:tag_name/release`
- [ ] [Update a release](https://docs.gitlab.com/ee/api/tags.html#update-a-release) `PUT /projects/:id/repository/tags/:tag_name/release`

# [To-Do lists](https://docs.gitlab.com/ee/api/todos.html)
- [x] [Get a list of todos](https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos) `GET /todos`
- [x] [Mark a todo as done](https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done) `POST /todos/:id/mark_as_done`
- [x] [Mark all todos as done](https://docs.gitlab.com/ee/api/todos.html#mark-all-todos-as-done) `POST /todos/mark_as_done`

# [Users](https://docs.gitlab.com/ee/api/users.html)
- [x] [For normal users](https://docs.gitlab.com/ee/api/users.html#for-normal-users) `GET /users`
- [x] [For user](https://docs.gitlab.com/ee/api/users.html#for-user) `GET /users/:id`
- [x] [User creation](https://docs.gitlab.com/ee/api/users.html#user-creation) `POST /users`
- [ ] [User modification](https://docs.gitlab.com/ee/api/users.html#user-modification) `PUT /users/:id`
- [ ] [Delete authentication identity from user](https://docs.gitlab.com/ee/api/users.html#delete-authentication-identity-from-user) `DELETE /users/:id/identities/:provider`
- [ ] [User deletion](https://docs.gitlab.com/ee/api/users.html#user-deletion) `DELETE /users/:id`
- [x] [List current user (for normal users)](https://docs.gitlab.com/ee/api/users.html#list-current-user-for-normal-users) `GET /user`
- [x] [User status](https://docs.gitlab.com/ee/api/users.html#user-status) `GET /user/status`
- [x] [Get the status of a user](https://docs.gitlab.com/ee/api/users.html#get-the-status-of-a-user) `GET /users/:id_or_username/status`
- [x] [Set user status](https://docs.gitlab.com/ee/api/users.html#set-user-status) `PUT /user/status`
- [ ] [User counts](https://docs.gitlab.com/ee/api/users.html#user-counts) `GET /user_counts`
- [x] [List SSH keys](https://docs.gitlab.com/ee/api/users.html#list-ssh-keys) `GET /user/keys`
- [x] [List SSH keys for user](https://docs.gitlab.com/ee/api/users.html#list-ssh-keys-for-user) `GET /users/:id_or_username/keys`
- [x] [Single SSH key](https://docs.gitlab.com/ee/api/users.html#single-ssh-key) `GET /user/keys/:key_id`
- [x] [Add SSH key](https://docs.gitlab.com/ee/api/users.html#add-ssh-key) `POST /user/keys`
- [x] [Add SSH key for user](https://docs.gitlab.com/ee/api/users.html#add-ssh-key-for-user) `POST /users/:id/keys`
- [x] [Delete SSH key for current user](https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-current-user) `DELETE /user/keys/:key_id`
- [x] [Delete SSH key for given user](https://docs.gitlab.com/ee/api/users.html#delete-ssh-key-for-given-user) `DELETE /users/:id/keys/:key_id`
- [ ] [List all GPG keys](https://docs.gitlab.com/ee/api/users.html#list-all-gpg-keys) `GET /user/gpg_keys`
- [ ] [Get a specific GPG key](https://docs.gitlab.com/ee/api/users.html#get-a-specific-gpg-key) `GET /user/gpg_keys/:key_id`
- [ ] [Add a GPG key](https://docs.gitlab.com/ee/api/users.html#add-a-gpg-key) `POST /user/gpg_keys`
- [ ] [Delete a GPG key](https://docs.gitlab.com/ee/api/users.html#delete-a-gpg-key) `DELETE /user/gpg_keys/:key_id`
- [ ] [List all GPG keys for given user](https://docs.gitlab.com/ee/api/users.html#list-all-gpg-keys-for-given-user) `GET /users/:id/gpg_keys`
- [ ] [Get a specific GPG key for a given user](https://docs.gitlab.com/ee/api/users.html#get-a-specific-gpg-key-for-a-given-user) `GET /users/:id/gpg_keys/:key_id`
- [ ] [Add a GPG key for a given user](https://docs.gitlab.com/ee/api/users.html#add-a-gpg-key-for-a-given-user) `POST /users/:id/gpg_keys`
- [ ] [Delete a GPG key for a given user](https://docs.gitlab.com/ee/api/users.html#delete-a-gpg-key-for-a-given-user) `DELETE /users/:id/gpg_keys/:key_id`
- [ ] [List emails](https://docs.gitlab.com/ee/api/users.html#list-emails) `GET /user/emails`
- [ ] [List emails for user](https://docs.gitlab.com/ee/api/users.html#list-emails-for-user) `GET /users/:id/emails`
- [ ] [Single email](https://docs.gitlab.com/ee/api/users.html#single-email) `GET /user/emails/:email_id`
- [ ] [Add email](https://docs.gitlab.com/ee/api/users.html#add-email) `POST /user/emails`
- [ ] [Add email for user](https://docs.gitlab.com/ee/api/users.html#add-email-for-user) `POST /users/:id/emails`
- [ ] [Delete email for current user](https://docs.gitlab.com/ee/api/users.html#delete-email-for-current-user) `DELETE /user/emails/:email_id`
- [ ] [Delete email for given user](https://docs.gitlab.com/ee/api/users.html#delete-email-for-given-user) `DELETE /users/:id/emails/:email_id`
- [ ] [Block user](https://docs.gitlab.com/ee/api/users.html#block-user) `POST /users/:id/block`
- [ ] [Unblock user](https://docs.gitlab.com/ee/api/users.html#unblock-user) `POST /users/:id/unblock`
- [ ] [Deactivate user](https://docs.gitlab.com/ee/api/users.html#deactivate-user) `POST /users/:id/deactivate`
- [ ] [Activate user](https://docs.gitlab.com/ee/api/users.html#activate-user) `POST /users/:id/activate`
- [ ] [Get all impersonation tokens of a user](https://docs.gitlab.com/ee/api/users.html#get-all-impersonation-tokens-of-a-user) `GET /users/:user_id/impersonation_tokens`
- [ ] [Get an impersonation token of a user](https://docs.gitlab.com/ee/api/users.html#get-an-impersonation-token-of-a-user) `GET /users/:user_id/impersonation_tokens/:impersonation_token_id`
- [x] [Create an impersonation token](https://docs.gitlab.com/ee/api/users.html#create-an-impersonation-token) `POST /users/:user_id/impersonation_tokens`
- [ ] [Revoke an impersonation token](https://docs.gitlab.com/ee/api/users.html#revoke-an-impersonation-token) `DELETE /users/:user_id/impersonation_tokens/:impersonation_token_id`
- [ ] [Get user activities (admin only)](https://docs.gitlab.com/ee/api/users.html#get-user-activities-admin-only) `GET /user/activities`
- [ ] [User memberships (admin only)](https://docs.gitlab.com/ee/api/users.html#user-memberships-admin-only) `GET /users/:id/memberships`

# [Variables (project)](https://docs.gitlab.com/ee/api/project_level_variables.html)
- [ ] [List project variables](https://docs.gitlab.com/ee/api/project_level_variables.html#list-project-variables) `GET /projects/:id/variables`
- [ ] [Show variable details](https://docs.gitlab.com/ee/api/project_level_variables.html#show-variable-details) `GET /projects/:id/variables/:key`
- [ ] [Create variable](https://docs.gitlab.com/ee/api/project_level_variables.html#create-variable) `POST /projects/:id/variables`
- [ ] [Update variable](https://docs.gitlab.com/ee/api/project_level_variables.html#update-variable) `PUT /projects/:id/variables/:key`
- [ ] [Remove variable](https://docs.gitlab.com/ee/api/project_level_variables.html#remove-variable) `DELETE /projects/:id/variables/:key`

# [Version](https://docs.gitlab.com/ee/api/version.html)
- [x] [Version API](https://docs.gitlab.com/ee/api/version.html#version-api) `GET /version`

# [Vulnerability Findings](https://docs.gitlab.com/ee/api/vulnerability_findings.html)
- [ ] [List project vulnerability findings](https://docs.gitlab.com/ee/api/vulnerability_findings.html#list-project-vulnerability-findings) `GET /projects/:id/vulnerability_findings`

# [Wikis](https://docs.gitlab.com/ee/api/wikis.html)
- [x] [List wiki pages](https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages) `GET /projects/:id/wikis`
- [x] [Get a wiki page](https://docs.gitlab.com/ee/api/wikis.html#get-a-wiki-page) `GET /projects/:id/wikis/:slug`
- [x] [Create a new wiki page](https://docs.gitlab.com/ee/api/wikis.html#create-a-new-wiki-page) `POST /projects/:id/wikis`
- [x] [Edit an existing wiki page](https://docs.gitlab.com/ee/api/wikis.html#edit-an-existing-wiki-page) `PUT /projects/:id/wikis/:slug`
- [x] [Delete a wiki page](https://docs.gitlab.com/ee/api/wikis.html#delete-a-wiki-page) `DELETE /projects/:id/wikis/:slug`
- [ ] [Upload an attachment to the wiki repository](https://docs.gitlab.com/ee/api/wikis.html#upload-an-attachment-to-the-wiki-repository) `POST /projects/:id/wikis/attachments`

# [Variables (group)](https://docs.gitlab.com/ee/api/group_level_variables.html)
- [ ] [List group variables](https://docs.gitlab.com/ee/api/group_level_variables.html#list-group-variables) `GET /groups/:id/variables`
- [ ] [Show variable details](https://docs.gitlab.com/ee/api/group_level_variables.html#show-variable-details) `GET /groups/:id/variables/:key`
- [ ] [Create variable](https://docs.gitlab.com/ee/api/group_level_variables.html#create-variable) `POST /groups/:id/variables`
- [ ] [Update variable](https://docs.gitlab.com/ee/api/group_level_variables.html#update-variable) `PUT /groups/:id/variables/:key`
- [ ] [Remove variable](https://docs.gitlab.com/ee/api/group_level_variables.html#remove-variable) `DELETE /groups/:id/variables/:key`

# [Vulnerabilities](https://docs.gitlab.com/ee/api/vulnerabilities.html)
- [ ] [Single vulnerability](https://docs.gitlab.com/ee/api/vulnerabilities.html#single-vulnerability) `GET /vulnerabilities/:id`
- [ ] [Confirm vulnerability](https://docs.gitlab.com/ee/api/vulnerabilities.html#confirm-vulnerability) `POST /vulnerabilities/:id/confirm`
- [ ] [Resolve vulnerability](https://docs.gitlab.com/ee/api/vulnerabilities.html#resolve-vulnerability) `POST /vulnerabilities/:id/resolve`
- [ ] [Dismiss vulnerability](https://docs.gitlab.com/ee/api/vulnerabilities.html#dismiss-vulnerability) `POST /vulnerabilities/:id/dismiss`

